namespace FinanceTracking.Entities
{
	using Interfaces;
	using System;
	using System.Collections.Generic;

	/// <summary>
	/// Чек
	/// </summary>
	public class Check : IBaseEntity
	{
		/// <inheritdoc>
		public long Id { get; set; }

		/// <summary>
		/// Лист покупок
		/// </summary>
		public List<Shopping> Shopping { get; set; }

		/// <summary>
		/// Дата покупки продуктов
		/// </summary>
		public DateTime ShoppingDate { get; set; } = DateTime.Now;

		/// <summary>
		/// Дата создания
		/// </summary>
		public DateTime CreateDate { get; set; } = DateTime.UtcNow;
	}
}
