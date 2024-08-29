using APModelsLibrary.Actions;
using APModelsLibrary.Interfaces;
using APModelsLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using PaymentsWeb.Models;
using System.Diagnostics;

namespace PaymentsWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAction _crudApi;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _crudApi = new PaymentActions();
        }

        public async Task<IActionResult> Index()
        {
            if (_crudApi != null)
            {
                var payments = await _crudApi.GetAllAsync();

                if (payments == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(payments);
                }
                
            }
            else
            {
                return Error();
            }
        }


        public IActionResult Contacts()
        {
            return View();
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PaymentModel payment)
        {
            if (payment != null && _crudApi != null)
            {
                bool result = await _crudApi.AddAsync(payment);

                if (result)
                {
                    return RedirectToAction("Index");
                }
            }

            return NotFound();
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null && _crudApi != null)
            {
                PaymentModel payment = await _crudApi.GetSingleAsync(id);

                if (payment != null)
                {
                    return View(payment);
                }
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PaymentModel payment)
        {
            if (payment != null && _crudApi != null)
            {
                bool result = await _crudApi.EditAsync(payment);

                if (result)
                {
                    return RedirectToAction("Index");
                }
            }

            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null && _crudApi != null)
            {
                bool isDeleted = await _crudApi.DeleteAsync(id);

                if (isDeleted)
                {
                    return RedirectToAction("Index");
                }
            }

            return NotFound();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
