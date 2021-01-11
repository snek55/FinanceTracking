namespace FinanceTracking.Shared.MainPage
{
	using System.Collections.ObjectModel;
	using Entities;
	using FinanceTracking.Extensions;
	using Microsoft.AspNetCore.Components;

	public partial class EditFormMainPage
	{
		private readonly Shopping _shopping = new();

		[Inject]
		private ObservableCollection<Shopping> _list { get; set; }

		private void HandleValidSubmit()
		{
			// TODO: проверка валидации
			var item = this._shopping.Clone();

			this._list.Add(item);
		}
	}
}