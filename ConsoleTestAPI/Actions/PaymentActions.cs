using APModelsLibrary.Models;
using ConsoleTestAPI.Classes;
using ConsoleTestAPI.Interfaces;
using System.Text;
using System.Text.Json;

namespace ConsoleTestAPI.Actions
{
    /// <summary>
    /// Запросы к REST API на чтение.
    /// </summary>
    public class PaymentActions : APIRequests, IAction
    {
        /// <summary>
        /// Показывать информацию ответа.
        /// </summary>
        private bool IsShowAPIAnswers { get; set; }


        public PaymentActions() : base()
        {
            IsShowAPIAnswers = false;
        }


        /// <summary>
        /// Получить список всех платежей.
        /// </summary>
        /// <returns></returns>
        public async Task GetAllAsync()
        {
            Console.WriteLine("\n\nЧтение всех данных");

            try
            {
                using (var client = new HttpClient())
                {
                    var _responseMessage = client.GetAsync(base.Request).Result;

                    if ((_responseMessage as HttpResponseMessage).IsSuccessStatusCode)
                    {
                        var xml = await (_responseMessage as HttpResponseMessage).Content.ReadAsStringAsync();
                        var restoredPayments = JsonSerializer.Deserialize<IEnumerable<PaymentModel>>(xml);

                        foreach (var payment in restoredPayments)
                        {
                            Console.WriteLine($"{payment.Id} - {payment.Period} - {payment.TotalSum}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// Получить платеж.
        /// </summary>
        /// <returns></returns>
        public async Task GetSingleAsync(int id)
        {
            Console.WriteLine("\n\nЧтение одной записи");

            try
            {
                using (var client = new HttpClient())
                {
                    var _responseMessage = client.GetAsync(String.Format(base.RequestOne, id)).Result;

                    if (IsShowAPIAnswers)
                    {
                        Console.WriteLine(_responseMessage.RequestMessage);
                        Console.WriteLine(_responseMessage.Content.ReadAsStringAsync().Result);
                        Console.WriteLine(_responseMessage.StatusCode);
                    }

                    if ((_responseMessage as HttpResponseMessage).IsSuccessStatusCode)
                    {
                        var xml = await (_responseMessage as HttpResponseMessage).Content.ReadAsStringAsync();
                        var restoredPayments = JsonSerializer.Deserialize<PaymentModel>(xml);

                        Console.WriteLine($"{restoredPayments.Id} - {restoredPayments.Period} - {restoredPayments.TotalSum}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Добавление платежа.
        /// </summary>
        /// <param name="payment">Модель платежа.</param>
        /// <returns></returns>
        public async Task AddAsync(PaymentModel payment)
        {
            Console.WriteLine("\n\nДобавление записи");

            var newPayment = JsonSerializer.Serialize<PaymentModel>(payment);
            HttpContent content = new StringContent(newPayment, Encoding.UTF8, "application/json");

            try
            {
                using (var client = new HttpClient())
                {
                    var _responseMessage = await client.PostAsync(base.Request, content);

                    if (IsShowAPIAnswers)
                    {
                        Console.WriteLine(_responseMessage.RequestMessage);
                        Console.WriteLine(_responseMessage.Content.ReadAsStringAsync().Result);
                        Console.WriteLine(_responseMessage.StatusCode);
                    }

                    if (_responseMessage.IsSuccessStatusCode)
                    {
                        var restoredPayments = JsonSerializer.Deserialize<PaymentModel>(_responseMessage.Content.ReadAsStringAsync().Result);
                        Console.WriteLine($"Id новой записи = {restoredPayments.Id}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        /// <summary>
        /// Изменение платежа.
        /// </summary>
        /// <param name="payment">Модель платежа.</param>
        /// <returns></returns>
        public async Task EditAsync(PaymentModel payment)
        {
            Console.WriteLine("\n\nРедактирование записи");

            var editPayment = JsonSerializer.Serialize<PaymentModel>(payment);
            var content = new StringContent(editPayment, Encoding.UTF8, "application/json");

            try
            {
                using (var client = new HttpClient())
                {
                    var _responseMessage = await client.PutAsync(String.Format(base.RequestOne, payment.Id), content);
                    _responseMessage.EnsureSuccessStatusCode();

                    if (IsShowAPIAnswers)
                    {
                        Console.WriteLine(_responseMessage.RequestMessage);
                        Console.WriteLine(_responseMessage.Content.ReadAsStringAsync().Result);
                        Console.WriteLine(_responseMessage.StatusCode);
                    }

                    if (_responseMessage.IsSuccessStatusCode)
                    {
                        var restoredPayments = JsonSerializer.Deserialize<PaymentModel>(_responseMessage.Content.ReadAsStringAsync().Result);
                        Console.WriteLine($"{restoredPayments.Id} - {restoredPayments.Period} - {restoredPayments.TotalSum}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        /// <summary>
        /// Удаление платежа.
        /// </summary>
        /// <param name="id">Id платежа.</param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            Console.WriteLine("\n\nУдаление записи");

            try
            {
                using (var client = new HttpClient())
                {
                    var _responseMessage = await client.DeleteAsync(String.Format(base.RequestOne, id));
                    _responseMessage.EnsureSuccessStatusCode();

                    if (IsShowAPIAnswers)
                    {
                        Console.WriteLine(_responseMessage.RequestMessage);
                        Console.WriteLine(_responseMessage.Content.ReadAsStringAsync().Result);
                        Console.WriteLine(_responseMessage.StatusCode);
                    }

                    if (_responseMessage.IsSuccessStatusCode)
                    {
                        var restoredPayments = JsonSerializer.Deserialize<PaymentModel>(_responseMessage.Content.ReadAsStringAsync().Result);
                        Console.WriteLine($"{restoredPayments.Id} - {restoredPayments.Period} - {restoredPayments.TotalSum}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
