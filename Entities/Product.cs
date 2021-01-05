namespace FinanceTracking.Entities
{
    using Enums;
    using Interfaces;

    /// <summary>
    /// Продукт
    /// </summary>
    public class Product : IBaseEntity {
        /// <inheritdoc/>>
        public long Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public decimal Quantity { get; set; }
    }
}