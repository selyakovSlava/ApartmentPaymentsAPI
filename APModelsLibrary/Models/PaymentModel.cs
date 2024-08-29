using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APModelsLibrary.Models
{
    /// <summary>
    /// Модель платежей.
    /// </summary>
    [Table("Payments")]
    [Serializable]
    public class PaymentModel
    {
        /// <summary>
        /// Id записи.
        /// </summary>
        [JsonPropertyName("id")]
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Код периода платежа.
        /// </summary>
        [JsonPropertyName("period")]
        public string Period { get; set; } = DateTime.Now.ToString("yyyyMM");

        /// <summary>
        /// Общая сумма платежа.
        /// </summary>
        [JsonPropertyName("totalsum")]
        public double TotalSum { get; set; }
        
    }
}
