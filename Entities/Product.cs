namespace FinanceTracking.Entities
{
    using Interfaces;

    public class Product : IHaveId
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public string Total => (Quantity * Price).ToString("F2");
    }
}