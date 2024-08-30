using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace ApartmentPaymentsAPI.RabbitMQ
{
    public class RabitMQProducer : IRabitMQProducer
    {
        public async Task<bool> SendPeriodMessage<T>(T message)
        {
            bool result = false;

            await Task.Factory.StartNew(() =>
            {
                var factory = new ConnectionFactory
                {
                    HostName = "localhost"
                };

                try
                {
                    var connection = factory.CreateConnection();

                    using
                    var channel = connection.CreateModel();

                    channel.QueueDeclare("period", exclusive: false);

                    var json = JsonConvert.SerializeObject(message);
                    var body = Encoding.UTF8.GetBytes(json);

                    channel.BasicPublish(exchange: "", routingKey: "period", body: body);

                    result = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Не удалось подключиться к RabbitMQ: {ex.Message}");
                }
            });

            return result;
        }
    }
}
