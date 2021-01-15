namespace FinanceTracking.Entities
{
	using System;
	using System.Linq;
	using Entities.Interfaces;
	using Enums;
	using Extensions;

	/// <summary>
	/// Фильтр статистики по указанному периоду
	/// </summary>
	public class PeriodTypeStatisticsFilter : IStatisticsFilter
	{
		/// <summary>
		/// Тип периода
		/// </summary>
		public StatisticsPeriodType PeriodType { get; set; }

		/// <summary>
		/// Количество единиц типа периода, применимо не для всех типов периодов
		/// </summary>
		public int PeriodUnitsCount { get; set; }

		/// <inheritdoc/>
		public Func<IQueryable<Check>, Statistics> GetQuery()
		{
			Func<IQueryable<Check>, Statistics> result = query =>
			{
				var response = new Statistics();

				var days = (int)(DateTime.Today - this.DateTimeForFilter).TotalDays + 1;
				response.AveragePreviousPeriodsExpenses = query.AverageValueForDaysPeriods(days);

				query = query.Where(c => c.ShoppingDate >= this.DateTimeForFilter);
				response.CurrentPeriodExpenses = query.Sum(c => c.Shopping.Sum(s => s.Price * s.Quantity));

				if (response.AveragePreviousPeriodsExpenses == 0L)
				{
					response.AveragePreviousPeriodsExpenses = response.CurrentPeriodExpenses;
				}

				return response;
			};

			return result;
		}

		/// <summary>
		/// Нужно ли отображать <see cref="PeriodUnitsCount">количество единиц периода</see>
		/// </summary>
		public bool IsNeedShowPeriodCount => this.PeriodUnitsCount > 1 && !this.PeriodType.IsConcreteDates();

		#region Helpers

		/// <summary>
		/// Получение даты начала отсчета текущего периода
		/// </summary>
		private DateTime DateTimeForFilter => this.PeriodType switch
		{
			StatisticsPeriodType.Day => DateTime.Today.AddDays(1 - this.PeriodUnitsCount),
			StatisticsPeriodType.Week => DateTime.Today.AddDays(1 - this.PeriodUnitsCount * 7),
			StatisticsPeriodType.Month => this.GetDateTimeForMonthFilter(),
			StatisticsPeriodType.Year => new DateTime(DateTime.Today.Year - this.PeriodUnitsCount, DateTime.Today.Month, DateTime.Today.Day),
			StatisticsPeriodType.Today => DateTime.Today,
			StatisticsPeriodType.StartOfWeek => DateTime.Today.DayOfWeek == DayOfWeek.Sunday
				? DateTime.Today.AddDays(-6)
				: DateTime.Today.AddDays(1 - (int)DateTime.Now.DayOfWeek),
			StatisticsPeriodType.StartOfMonth => DateTime.Today.AddDays(1 - DateTime.Today.Day),
			StatisticsPeriodType.StartOfYear => DateTime.Today.AddDays(1 - DateTime.Today.DayOfYear),
			_ => throw new NotImplementedException()
		};

		/// <summary>
		/// Для месяцев логика выполнения посложнее, потому вот такой метод
		/// </summary>
		private DateTime GetDateTimeForMonthFilter()
		{
			var year = DateTime.Today.Year;
			var month = DateTime.Today.Month;
			var day = DateTime.Today.Day;

			if (DateTime.Today.Month <= this.PeriodUnitsCount)
			{
				var count = this.PeriodUnitsCount;
				while (count > 12)
				{
					--year;
					count -= 12;
				}

				--year;
				month = 12 + DateTime.Today.Month - this.PeriodUnitsCount;
			}
			else
			{
				month -= this.PeriodUnitsCount;
			}

			return new DateTime(year, month, day);
		}

		#endregion
	}
}
