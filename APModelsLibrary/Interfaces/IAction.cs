using APModelsLibrary.Models;

namespace APModelsLibrary.Interfaces
{
    public interface IAction
    {
        /// <summary>
        /// Загрузить все записи.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PaymentModel>> GetAllAsync();

        /// <summary>
        /// Загрузить одну запись.
        /// </summary>
        /// <param name="id">Id записи.</param>
        /// <returns></returns>
        Task<PaymentModel> GetSingleAsync(int? id);

        /// <summary>
        /// Добавить запись.
        /// </summary>
        /// <param name="payment">Модель платежа.</param>
        /// <returns></returns>
        Task<bool> AddAsync(PaymentModel payment);

        /// <summary>
        /// Редактировать запись.
        /// </summary>
        /// <param name="payment">Модель платежа.</param>
        /// <returns></returns>
        Task<bool> EditAsync(PaymentModel payment);

        /// <summary>
        /// Удалитиь запись.
        /// </summary>
        /// <param name="id">Id записи.</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int? id);
    }
}
