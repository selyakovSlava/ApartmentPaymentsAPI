using APModelsLibrary.Actions;
using APModelsLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PaymentsWeb.Controllers
{
    public class ColumnChartController : Controller
    {
        private readonly IAction _crudApi;

        public ColumnChartController()
        {
            _crudApi = new PaymentActions();
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<JsonResult> PaymentChart()
        {
            var payments = await _crudApi.GetAllAsync();
            return Json(payments);
        }
    }
}
