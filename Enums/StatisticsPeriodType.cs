﻿namespace FinanceTracking.Enums
{
	/// <summary>
	/// Тип периодичности для статистики.
	/// Шаг больше 10 для месяца и года на случай, если будет что-то добавляться между ними (спринт, квартал и т.п.)
	/// Значения окончаний:
	/// *0 - стандартный параметр
	/// *1 - статистика за текущий (иногда не полный) элемент, например: для четверга статистика StartOfWeek будет с понедельника по четверг, а среднее значение будет считаться за полные недели перед этим (с понедельника по воскресенье)
	/// </summary>
	public enum StatisticsPeriodType
	{
		Day = 0,
		Week = 10,
		Month = 40,
		Year = 100,
		Today = 1,
		StartOfWeek = 11,
		StartOfMonth = 41,
		StartOfYear = 101
	}
}
