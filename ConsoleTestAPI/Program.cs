


using APModelsLibrary.Actions;
using APModelsLibrary.Interfaces;
using APModelsLibrary.Models;


Console.WriteLine("Тестирование REST API");


IAction action = new PaymentActions();

await LoadAllPaymentsTest(action);
await LoadSinglePaymentTest(action);
await AddPaymentTest(action);
await EditPaymentTest(action);
await DeletePaymentTest(action);

Console.ReadLine();



// Загрузка всех платежей.
static async Task LoadAllPaymentsTest(IAction action)
{
    IEnumerable<PaymentModel> payments = await action.GetAllAsync();

    foreach (var payment in payments)
    {
        Console.WriteLine($"{payment.Id} - {payment.Period} - {payment.TotalSum}");
    }
}


// Загрузка одного платежа.
static async Task LoadSinglePaymentTest(IAction action)
{
    PaymentModel payments = await action.GetSingleAsync(11);

    Console.WriteLine($"{payments.Id} - {payments.Period} - {payments.TotalSum}");
}


// Добавление платежа.
static async Task AddPaymentTest(IAction action)
{
    PaymentModel payments = new PaymentModel()
    {
        Period = "2024",
        TotalSum = 5235.76
    };

    bool result = await action.AddAsync(payments);
    
    if (result)
    {
        Console.WriteLine("Запись успешно добавлена");
    }
    else
    {
        Console.WriteLine("Ошибка добавления записи");
    }
}

// Редактирование платежа.
static async Task EditPaymentTest(IAction action)
{
    PaymentModel payments = new PaymentModel()
    {
        Id = 1,
        Period = "2024",
        TotalSum = 100
    };

    bool result = await action.EditAsync(payments);

    if (result)
    {
        Console.WriteLine("Запись успешно изменена");
    }
    else
    {
        Console.WriteLine("Ошибка изменения записи");
    }
}

// Удаление платежа.
static async Task DeletePaymentTest(IAction action)
{
    PaymentModel payments = new PaymentModel()
    {
        Id = 1,
        Period = "2024",
        TotalSum = 0
    };

    bool result = await action.DeleteAsync(payments.Id);

    if (result)
    {
        Console.WriteLine("Запись успешно удалена");
    }
    else
    {
        Console.WriteLine("Ошибка удаления записи");
    }
}