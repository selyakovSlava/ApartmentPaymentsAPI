using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APModelsLibrary.Models;
using ApartmentPaymentsAPI.DataContexts;

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

        public PaymentsController(DataContext context)
        {
            _context = context;
        }

       /* public async Task<IActionResult> Index()
        {
            return View();
        }*/

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
            }

            await _context.SaveChangesAsync();
            return Ok("Deleted information successfully!");
        }

        /*// GET: Payments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Period,TotalSum")] PaymentModel paymentModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentModel);
        }

        // GET: Payments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentModel = await _context.Payments.FindAsync(id);
            if (paymentModel == null)
            {
                return NotFound();
            }
            return View(paymentModel);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Period,TotalSum")] PaymentModel paymentModel)
        {
            if (id != paymentModel.Id)
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
                return RedirectToAction(nameof(Index));
            }
            return View(paymentModel);
        }

        // GET: Payments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentModel = await _context.Payments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentModel == null)
            {
                return NotFound();
            }

            return View(paymentModel);
        }

        // POST: Payments/Delete/5
        [ValidateAntiForgeryToken]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paymentModel = await _context.Payments.FindAsync(id);
            if (paymentModel != null)
            {
                _context.Payments.Remove(paymentModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }*/

        private bool PaymentModelExists(int id)
        {
            return _context.Payments.Any(e => e.Id == id);
        }
    }
}
