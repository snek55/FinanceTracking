﻿namespace FinanceTracking.Services.Interfaces
{
	using System.Threading.Tasks;
	using Entities;
	using Entities.Interfaces;

	public interface IStatisticService
	{
		/// <summary>
		/// Получение статистики по фильтру
		/// </summary>
		Task<Statistics> GetStatisticsAsync(IStatisticsFilter filter);
	}
}
