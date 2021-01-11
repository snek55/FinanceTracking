namespace FinanceTracking.Entities
{
	using Interfaces;
	/// <summary>
	/// Валюта
	/// </summary>
	public class Value : IBaseEntity
	{
		/// <inheritdoc/>
		public long Id { get; set; }
		/// <summary>
		/// Название валюты
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Знак валюты, добавляющийся в таблицу
		/// </summary>
		public char Symbol { get; set; }
	}
}
