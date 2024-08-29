


using APModelsLibrary.Actions;
using APModelsLibrary.Interfaces;
using APModelsLibrary.Models;
/*using ConsoleTestAPI.Actions;
using ConsoleTestAPI.Interfaces;*/


Console.WriteLine("Тестирование REST API");

/*IAction crudActions = new PaymentActions();

await crudActions.GetAllAsync();

await crudActions.GetSingleAsync(1);

await crudActions.AddAsync(new PaymentModel() { Period = "202112", TotalSum = 4583.81 });
await crudActions.AddAsync(new PaymentModel() { Period = "202201", TotalSum = 5040.50 });
await crudActions.AddAsync(new PaymentModel() { Period = "202202", TotalSum = 6100.75 });
await crudActions.AddAsync(new PaymentModel() { Period = "202203", TotalSum = 4979.72 });
await crudActions.AddAsync(new PaymentModel() { Period = "202204", TotalSum = 5125.69 });
await crudActions.AddAsync(new PaymentModel() { Period = "202205", TotalSum = 4569.91 });
await crudActions.AddAsync(new PaymentModel() { Period = "202206", TotalSum = 100 });
await crudActions.AddAsync(new PaymentModel() { Period = "202207", TotalSum = 100 });

await crudActions.EditAsync(new PaymentModel() { Id = 7, Period = "202206", TotalSum = 4231.79 });

await crudActions.DeleteAsync(8);*/


IAction action = new PaymentActions();

IEnumerable<PaymentModel> payments = await action.GetAllAsync();



Console.ReadLine();
