namespace FinanceTracking.Entities
{
	using Interfaces;

	/// <summary>
	/// Покупка
	/// </summary>
	public class Shopping : IBaseEntity
	{
		/// <inheritdoc>
		public long Id { get; set; }

		/// <summary>
		/// Продукт
		/// </summary>
		public Product Product { get; set; }

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
		public string Total => (this.Quantity * this.Price).ToString("0.##");

		public Shopping()
		{
			this.Product = new();
		}
	}
}
