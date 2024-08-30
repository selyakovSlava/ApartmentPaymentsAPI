using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APModelsLibrary.Models;
using ApartmentPaymentsAPI.DataContexts;
using ApartmentPaymentsAPI.RabbitMQ;

namespace ApartmentPaymentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : Controller
    {
        /// <summary>
        /// Контекст данных.
        /// </summary>
        private readonly DataContext _context;

        /// <summary>
        /// RabbitMQ.
        /// </summary>
        private readonly IRabitMQProducer _rabitMQProducer;

        /// <summary>
        /// Логгер.
        /// </summary>
        private readonly ILogger<PaymentsController> _logger;

        public PaymentsController(DataContext context, IRabitMQProducer rabitMQProducer, ILogger<PaymentsController> logger)
        {
            _context = context;
            _rabitMQProducer = rabitMQProducer;
            _logger = logger;
        }


        // Get: api/payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentModel>>> GetPayemnts()
        {
            if (_context.Payments == null)
            {
                return NotFound();
            }

            return await _context.Payments.ToListAsync();
        }

        // GET: api/payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentModel>> GetPayment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (_context.Payments == null)
            {
                return NotFound();
            }

            var paymentModel = await _context.Payments.FirstOrDefaultAsync(m => m.Id == id);
            
            if (paymentModel == null)
            {
                return NotFound();
            }

            return paymentModel;
        }


        [HttpPost]
        public async Task<ActionResult<PaymentModel>> CreatePayment([Bind("Id,Period,TotalSum")] PaymentModel paymentModel)
        {
            if (_context.Payments == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Add(paymentModel);
                await _context.SaveChangesAsync();

                SendMessageToRabbitMQ($"Создан новый период {paymentModel.Period}");

                return CreatedAtAction("GetPayment", new { id = paymentModel.Id }, paymentModel);
            }
            else
            {
                return NotFound(ModelState);
            }
        }

        // Edit: api/payments/5
        [HttpPut("{id}")]
        public async Task<ActionResult<PaymentModel>> EditPayment(int id, [Bind("Id,Period,TotalSum")] PaymentModel paymentModel)
        {
            if (id != paymentModel.Id)
            {
                return NotFound();
            }

            if (_context.Payments == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentModelExists(paymentModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return CreatedAtAction("GetPayment", new { id = paymentModel.Id }, paymentModel);
            }

            return NotFound();
        }


        // DELETE: api/payments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            if (_context.Payments == null)
            {
                return NotFound();
            }

            var paymentModel = await _context.Payments.FindAsync(id);
            
            if (paymentModel != null)
            {
                _context.Payments.Remove(paymentModel);
                await _context.SaveChangesAsync();

                SendMessageToRabbitMQ($"Удален период {paymentModel.Period}");
            }

            return Ok("Deleted information successfully!");
        }

        private bool PaymentModelExists(int id)
        {
            return _context.Payments.Any(e => e.Id == id);
        }

        /// <summary>
        /// Отправка сообщения в очередь RabbitMQ.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        private async void SendMessageToRabbitMQ(string message)
        {
            if (_rabitMQProducer != null)
            {
                bool result = await _rabitMQProducer.SendPeriodMessage(message);

                if (!result && _logger != null)
                {
                    _logger.LogError($"{DateTime.Now}: Не удалось отправить сообщение в RabbitMQ");
                }

                if (result && _logger != null)
                {
                    _logger.LogInformation($"{DateTime.Now}: Cообщение отправлено в RabbitMQ");
                }
            }
        }
    }
}
