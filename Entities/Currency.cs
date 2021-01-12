namespace FinanceTracking.Entities
{
	using FinanceTracking.Entities.Interfaces;
	using FinanceTracking.Enums;

	/// <summary>
	/// Тип валюты
	/// </summary>
	public class Currency : IBaseEntity
	{
		/// <summary>
		/// Ид
		/// </summary>
		public long Id { get; set; }
		/// <summary>
		/// Полное имя типа валюты
		/// </summary>
		public string LongName { get; set; }
		/// <summary>
		/// Короткое имя типа валюты (EUR)
		/// </summary>
		public string ShortName { get; set; }
		/// <summary>
		/// Символ типа валюты ($)
		/// </summary>
		public char Symbol { get; set; }
		public Currencies CurType { get; set; }
	}
}
