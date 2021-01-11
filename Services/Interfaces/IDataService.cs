namespace FinanceTracking.Services.Interfaces
{
	using FinanceTracking.Entities;
	using System;
	using System.Linq;
	using System.Threading.Tasks;

	public interface IDataService
	{
		/// <summary>
		/// Получение статистики по запросу
		/// </summary>
		Task<T> GetStatisticsAsync<T>(Func<IQueryable<Check>, T> request);
	}
}
