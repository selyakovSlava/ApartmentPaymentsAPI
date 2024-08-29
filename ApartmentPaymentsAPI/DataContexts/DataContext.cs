using APModelsLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ApartmentPaymentsAPI.DataContexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        /// <summary>
        /// Набор данных о платежах.
        /// </summary>
        public DbSet<PaymentModel> Payments { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Установка значений по умолчанию при создании бд.
            modelBuilder.Entity<PaymentModel>().HasData(
                    new PaymentModel { Id = 1, Period = "202112", TotalSum = 4583.81 }
            );
        }
    }
}
