namespace FinanceTracking.Entities.Interfaces
{
	using System;
	using System.Linq;

	/// <summary>
	/// Интерфейс фильтра статистики
	/// </summary>
	public interface IStatisticsFilter
	{
		/// <summary>
		/// Получить запрос на выполнение как IQueryable
		/// </summary>
		Func<IQueryable<Check>, Statistics> GetQuery();
	}
}
