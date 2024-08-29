using APModelsLibrary.Models;
using APModelsLibrary.Classes;
using APModelsLibrary.Interfaces;
using System.Text;
using System.Text.Json;

namespace APModelsLibrary.Actions
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
        public async Task<IEnumerable<PaymentModel>> GetAllAsync()
        {
            IEnumerable<PaymentModel> payments = null;

            try
            {
                using (var client = new HttpClient())
                {
                    var _responseMessage = client.GetAsync(base.Request).Result;

                    if ((_responseMessage as HttpResponseMessage).IsSuccessStatusCode)
                    {
                        var xml = await (_responseMessage as HttpResponseMessage).Content.ReadAsStringAsync();
                        payments = JsonSerializer.Deserialize<IEnumerable<PaymentModel>>(xml);
                    }
                    else
                    {
                        Console.WriteLine("Говно");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return payments;
        }


        /// <summary>
        /// Получить платеж.
        /// </summary>
        /// <returns></returns>
        public async Task<PaymentModel> GetSingleAsync(int? id)
        {
            PaymentModel model = null;

            if (id != null)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        var _responseMessage = client.GetAsync(String.Format(base.RequestOne, id)).Result;

                        if ((_responseMessage as HttpResponseMessage).IsSuccessStatusCode)
                        {
                            var xml = await (_responseMessage as HttpResponseMessage).Content.ReadAsStringAsync();
                            model = JsonSerializer.Deserialize<PaymentModel>(xml);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return model;
        }

        /// <summary>
        /// Добавление платежа.
        /// </summary>
        /// <param name="payment">Модель платежа.</param>
        /// <returns></returns>
        public async Task<bool> AddAsync(PaymentModel payment)
        {
            bool result = false;

            if (payment != null)
            {
                var newPayment = JsonSerializer.Serialize<PaymentModel>(payment);
                HttpContent content = new StringContent(newPayment, Encoding.UTF8, "application/json");

                try
                {
                    using (var client = new HttpClient())
                    {
                        var _responseMessage = await client.PostAsync(base.Request, content);
                        result = _responseMessage.IsSuccessStatusCode;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }            

            return result;
        }



        /// <summary>
        /// Изменение платежа.
        /// </summary>
        /// <param name="payment">Модель платежа.</param>
        /// <returns></returns>
        public async Task<bool> EditAsync(PaymentModel payment)
        {
            bool result = false;

            if (payment != null)
            {
                var editPayment = JsonSerializer.Serialize<PaymentModel>(payment);
                var content = new StringContent(editPayment, Encoding.UTF8, "application/json");

                try
                {
                    using (var client = new HttpClient())
                    {
                        var _responseMessage = await client.PutAsync(String.Format(base.RequestOne, payment.Id), content);
                        _responseMessage.EnsureSuccessStatusCode();
                        result = _responseMessage.IsSuccessStatusCode;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return result;
        }



        /// <summary>
        /// Удаление платежа.
        /// </summary>
        /// <param name="id">Id платежа.</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(int? id)
        {
            bool result = false;

            if (id != null)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        var _responseMessage = await client.DeleteAsync(String.Format(base.RequestOne, id));
                        _responseMessage.EnsureSuccessStatusCode();
                        result = _responseMessage.IsSuccessStatusCode;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return result;
        }
    }
}
