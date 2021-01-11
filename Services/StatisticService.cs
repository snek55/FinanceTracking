namespace FinanceTracking.Services
{
	using System.Threading.Tasks;
	using FinanceTracking.Entities;
	using FinanceTracking.Entities.Interfaces;
	using FinanceTracking.Services.Interfaces;

	/// <summary>
	/// Сервис статистики, пока не придумал, как его расширить
	/// </summary>
	public class StatisticService : IStatisticService
	{
		private readonly IDataService _dataService;

		public StatisticService(IDataService dataService)
		{
			this._dataService = dataService;
		}

		/// <inheritdoc/>
		public Task<Statistics> GetStatisticsAsync(IStatisticsFilter filter)
		{
			var request = filter.GetQuery();

			return this._dataService.GetStatisticsAsync(request);
		}
	}
}
