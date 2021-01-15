namespace FinanceTracking.Pages
{
	using System;
	using System.Threading.Tasks;
	using Entities;
	using Entities.Interfaces;
	using Enums;
	using Extensions;
	using Services.Interfaces;
	using Microsoft.AspNetCore.Components;

	public partial class Statistics
	{
		public bool IsCustomDatesPeriod { get; set; }
		public bool IsLoading { get; set; }
		public int Count { get; set; } = 1;
		public StatisticsPeriodType PeriodType { get; set; } = StatisticsPeriodType.Today;
		public DateTime? From { get; set; }
		public DateTime? To { get; set; }
		public string PeriodDescription { get; set; }
		public Entities.Statistics CurrentStatistic { get; set; } = new();

		[Inject]
		public IStatisticService StatisticService { get; set; }

		protected override async Task OnInitializedAsync() => await this.UpdateStatistics();

		public async Task UpdateStatistics()
		{
			this.IsLoading = true;
			this.PeriodDescription = string.Empty;

			IStatisticsFilter filter = this.IsCustomDatesPeriod
				? new CustomDatesStatisticsFilter { From = this.From, To = this.To }
				: new PeriodTypeStatisticsFilter { PeriodType = this.PeriodType, PeriodUnitsCount = this.Count };

			this.CurrentStatistic = await this.StatisticService.GetStatisticsAsync(filter);
			this.PeriodDescription = filter.FilteredDatesText();

			this.StateHasChanged();

			this.IsLoading = false;
		}
	}
}
