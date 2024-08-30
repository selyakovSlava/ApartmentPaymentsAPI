namespace ApartmentPaymentsAPI.RabbitMQ
{
    public interface IRabitMQProducer
    {
        public Task<bool> SendPeriodMessage<T>(T message);
    }
}
