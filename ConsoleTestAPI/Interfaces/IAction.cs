using APModelsLibrary.Models;

namespace ConsoleTestAPI.Interfaces
{
    public interface IAction
    {
        /// <summary>
        /// Загрузить все записи.
        /// </summary>
        /// <returns></returns>
        Task GetAllAsync();

        /// <summary>
        /// Загрузить одну запись.
        /// </summary>
        /// <param name="id">Id записи.</param>
        /// <returns></returns>
        Task GetSingleAsync(int id);

        /// <summary>
        /// Добавить запись.
        /// </summary>
        /// <param name="payment">Модель платежа.</param>
        /// <returns></returns>
        Task AddAsync(PaymentModel payment);

        /// <summary>
        /// Редактировать запись.
        /// </summary>
        /// <param name="payment">Модель платежа.</param>
        /// <returns></returns>
        Task EditAsync(PaymentModel payment);

        /// <summary>
        /// Удалитиь запись.
        /// </summary>
        /// <param name="id">Id записи.</param>
        /// <returns></returns>
        Task DeleteAsync(int id);
    }
}
