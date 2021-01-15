namespace FinanceTracking.Extensions
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Entities;
	using Entities.Interfaces;
	using Enums;

	public static class DefaultExtensions
	{
		/// <summary>
		/// Получить конец текущего дня
		/// </summary>
		/// <param name="dateTime">Дата для получения текущего дня</param>
		public static DateTime EndOfDay(this DateTime dateTime) => dateTime.Date.AddDays(1).AddTicks(-1);

		/// <summary>
		/// Получить конец текущего дня
		/// </summary>
		/// <param name="dateTime">Дата для получения текущего дня</param>
		public static DateTime? EndOfDay(this DateTime? dateTime) => dateTime?.Date.AddDays(1).AddTicks(-1) ?? null;

		/// <summary>
		/// Получение описания статистики для отображения
		/// Например: "Статистика за сегодня"
		/// </summary>
		/// <param name="filter">Фильтр статистики для отображения</param>
		/// <param name="datetimeFormat">Формат дат</param>
		/// <returns></returns>
		public static string FilteredDatesText<T>(this T filter, string datetimeFormat = "D") where T : class, IStatisticsFilter
		{
			var textWithDates = "Statistics for ";
			textWithDates += StatisticsFilterToText((dynamic)filter, datetimeFormat);

			return textWithDates;
		}

		/// <summary>
		/// Является ли период самосодержащим количество единиц периода (типы, отвечающие за текущий период: сегодня, эта неделя и т.д.)
		/// </summary>
		/// <returns>True, если является, т.е. количество единиц периода не требуется</returns>
		public static bool IsConcreteDates(this StatisticsPeriodType periodType) => ((int)periodType) % 10 == 1;

		/// <summary>
		/// Текст для отображения в зависимости от типа периода
		/// </summary>
		public static string ToText(this StatisticsPeriodType type, int count) => type switch
		{
			StatisticsPeriodType.Day => DaysCountToString[PeriodUnitsToIndex(count)],
			StatisticsPeriodType.Week => WeeksCountToString[PeriodUnitsToIndex(count)],
			StatisticsPeriodType.Month => MonthsCountToString[PeriodUnitsToIndex(count)],
			StatisticsPeriodType.Year => YearsCountToString[PeriodUnitsToIndex(count)],
			StatisticsPeriodType.Today => "today",
			StatisticsPeriodType.StartOfWeek =>
			DateTime.Now.DayOfWeek == DayOfWeek.Monday
				? "this week"
				: $"this week from Monday to {DateTime.Now:dddd}",
			StatisticsPeriodType.StartOfMonth => DateTime.Now.ToString("MMMM"),
			StatisticsPeriodType.StartOfYear => DateTime.Now.ToString("yyyy"),
			_ => throw new NotImplementedException()
		};

		/// <summary>
		/// Вычислить средние траты за определенное количество дней
		/// </summary>
		public static decimal AverageValueForDaysPeriods(this IQueryable<Check> query, int days)
		{
			var orderedQuery = query.OrderBy(c => c.ShoppingDate);
			var firstDate = orderedQuery.FirstOrDefault()?.ShoppingDate.Date ?? DateTime.Today;
			var lastDate = (orderedQuery.LastOrDefault()?.ShoppingDate.Date ?? DateTime.Today).EndOfDay();

			var totalDays = (int)(lastDate - firstDate).TotalDays;

			if (days < totalDays)
			{
				if (days <= 1)
				{
					return query.GroupBy(c => c.ShoppingDate.Date).Average(x => x.Sum(c => c.Shopping.Sum(s => s.Price * s.Quantity)));
				}

				List<decimal> averageExpesesList = new List<decimal>();

				for (var i = totalDays; i > 0; i -= days)
				{
					var currentFirstDate = firstDate.AddDays(i);

					var sum = query
						.Where(c => c.ShoppingDate >= currentFirstDate && c.ShoppingDate < currentFirstDate.AddDays(days))
						.Sum(c => c.Shopping.Sum(s => s.Price * s.Quantity));

					if(i < days)
					{
						sum = sum * days / i;
					}

					averageExpesesList.Add(sum);
				}

				return averageExpesesList.Average();
			}

			return 0L;
		}

		#region Helpers

		/// <summary>
		/// Получение надписи о статистике в зависимости от типа статистики
		/// </summary>
		private static string StatisticsFilterToText(object filter, string datetimeFormat) => throw new ArgumentOutOfRangeException();

		/// <summary>
		/// Получение надписи о статистике в зависимости от типа статистики
		/// </summary>
		private static string StatisticsFilterToText(PeriodTypeStatisticsFilter filter, string datetimeFormat)
		{
			var response = filter.IsNeedShowPeriodCount
				? $"{filter.PeriodUnitsCount} "
				: string.Empty;

			response += filter.PeriodType.ToText(filter.PeriodUnitsCount);

			return response;
		}

		/// <summary>
		/// Получение надписи о статистике в зависимости от типа статистики
		/// </summary>
		private static string StatisticsFilterToText(CustomDatesStatisticsFilter filter, string datetimeFormat)
		{
			if (filter.From is null && filter.To is null)
			{
				return "all time";
			}

			if (filter.From?.Date == filter.To?.Date)
			{
				var date = filter.From?.Date;
				var text = DaysToText.FirstOrDefault(d => DateTime.Now.AddDays(d.Key).Date == date).Value
					?? date?.ToString(datetimeFormat);

				return text;
			}

			// TODO: Доделать проверки для недели, месяца, года и т.д.

			var response = "period";
			response += DateWithWordToFormat(filter.From, "from", datetimeFormat);
			response += DateWithWordToFormat(filter.To, "to", datetimeFormat);

			return response;
		}

		private static string DateWithWordToFormat(DateTime? date, string word, string format)
			=> date is null
				? string.Empty
				: $" {word} {date?.ToString(format)}";

		private static readonly Dictionary<int, string> DaysToText = new Dictionary<int, string>
		{
			{-1, "yesterday" },
			{0, "today"},
			{1, "tomorrow" }
		};

		/// <summary>
		/// Вычисление индекса по последней цифре количества единиц подсчета
		/// </summary>
		private static int PeriodUnitsToIndex(int count)
		{
			var mod = count % 10;
			return mod == 1
				? 0
				: 1;
		}

		private static readonly string[] YearsCountToString = { "year", "years" };
		private static readonly string[] MonthsCountToString = { "month", "months" };
		private static readonly string[] WeeksCountToString = { "week", "weeks" };
		private static readonly string[] DaysCountToString = { "day", "days" };

		#endregion
	}
}
