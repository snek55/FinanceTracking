namespace FinanceTracking.Entities
{
	using System;
	using System.Linq;
	using Entities.Interfaces;
	using Extensions;

	/// <summary>
	/// Фильтр статистики по вручную введенному промежутку дат
	/// </summary>
	public class CustomDatesStatisticsFilter : IStatisticsFilter
	{
		public DateTime? From { get; set; }
		public DateTime? To { get; set; }

		/// <inheritdoc/>
		public Func<IQueryable<Check>, Statistics> GetQuery()
		{
			Func<IQueryable<Check>, Statistics> result = query =>
			{
				var response = new Statistics();

				if (this.From is not null || this.To is not null)
				{
					var orderedQuery = query.OrderBy(c => c.ShoppingDate);
					var firstDate = orderedQuery.FirstOrDefault()?.ShoppingDate.Date ?? DateTime.Today;
					var lastDate = (orderedQuery.LastOrDefault()?.ShoppingDate.Date ?? DateTime.Today).EndOfDay();
					var from = this.From ?? firstDate;
					var to = this.To ?? lastDate;

					var days = (int)(to - from).TotalDays;
					response.AveragePreviousPeriodsExpenses = query.AverageValueForDaysPeriods(days);

					query = this.GetChecksByDates(query);
				}

				response.CurrentPeriodExpenses = query.Sum(c => c.Shopping.Sum(s => s.Price * s.Quantity));

				if (response.AveragePreviousPeriodsExpenses == 0L)
				{
					response.AveragePreviousPeriodsExpenses = response.CurrentPeriodExpenses;
				}

				return response;
			};

			return result;
		}

		private IQueryable<Check> GetChecksByDates(IQueryable<Check> query)
		{
			if (this.From is not null)
			{
				query = query.Where(p => p.ShoppingDate > this.From.Value.Date);
			}

			if (this.To is not null)
			{
				query = query.Where(p => p.ShoppingDate <= (this.To.Value.EndOfDay()));
			}

			return query;
		}
	}
}
