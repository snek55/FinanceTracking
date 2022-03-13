namespace FinanceTracking.Entities;

using Enums;
using Interfaces;

/// <summary>
///     Тип валюты
/// </summary>
public class Currency : IBaseEntity
{
	/// <summary>
	///     Полное имя типа валюты
	/// </summary>
	public string LongName { get; set; }

	/// <summary>
	///     Символ типа валюты ($)
	/// </summary>
	public char Symbol { get; set; }

	/// <summary>
	///     Тип валюты
	/// </summary>
	public Currencies CurType { get; set; }

	/// <summary>
	///     Ид
	/// </summary>
	public long Id { get; set; }
}