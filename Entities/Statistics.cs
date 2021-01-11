namespace FinanceTracking.Entities
{
	/// <summary>
	/// Итоговая статистика для выбранных фильтров
	/// </summary>
	public class Statistics
	{
		/// <summary>
		/// Траты за текущий период
		/// </summary>
		public decimal CurrentPeriodExpenses { get; set; }

		/// <summary>
		/// Средние траты за аналогичный период
		/// </summary>
		public decimal AveragePreviousPeriodsExpenses { get; set; }

		/// <summary>
		/// Разница относительно средних трат
		/// TODO: Для периодов с неполными промежутками (эта неделя/месяц/год) доделать ручной подсчет
		/// </summary>
		public decimal ExpensesDifference => this.AveragePreviousPeriodsExpenses - this.CurrentPeriodExpenses;
	}
}
