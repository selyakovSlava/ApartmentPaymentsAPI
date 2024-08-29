
namespace ConsoleTestAPI.Classes
{
    public abstract class APIRequests
    {
        /// <summary>
        /// Шаблон запроса для чтения всех данных, а также POST.
        /// </summary>
        public readonly string Request = "http://localhost:5199/api/payments";

        /// <summary>
        /// Шаблон запроса для чтения одной записи, а также DELETE, PUT.
        /// </summary>
        public readonly string RequestOne = "http://localhost:5199/api/payments/{0}";
    }
}
