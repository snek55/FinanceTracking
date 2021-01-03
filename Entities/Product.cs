namespace FinanceTracking.Entities
{
    using Interfaces;

    public class Product : IBaseEntities
    {
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

        /// <summary>
        /// Цена
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Итоговая сумма
        /// </summary>
        public string Total => (Quantity * Price).ToString("F2");
    }
}