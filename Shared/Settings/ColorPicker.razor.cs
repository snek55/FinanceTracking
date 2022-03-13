namespace FinanceTracking.Shared.Settings
{
	using Microsoft.AspNetCore.Components;
	using Blazored.LocalStorage;
	public partial class ColorPicker
    {
        const string defaultcolor = "#ffffff";

        [Inject]
        private ISyncLocalStorageService LocalStorage { get; set; }

        private string CommBackgroundColor
        {
            get => this.GetFromLocalStorage(nameof(this.CommBackgroundColor));
            set => this.UpdateLocalStorage(nameof(this.CommBackgroundColor), value);
        }

        private string FontBackgroundColor 
        {
            get => this.GetFromLocalStorage(nameof(this.FontBackgroundColor));
            set => this.UpdateLocalStorage(nameof(this.FontBackgroundColor), value); 
        }

        private string FontForegroundColor 
        {
            get => this.GetFromLocalStorage(nameof(this.FontForegroundColor));
            set => this.UpdateLocalStorage(nameof(this.FontForegroundColor), value);
        }

        private void UpdateLocalStorage(string k, string v)
        {
			this.LocalStorage.SetItem(k, v);
        }

        private string GetFromLocalStorage(string k)
        {
            return this.LocalStorage.ContainKey(k) 
				? this.LocalStorage.GetItem<string>(k) 
				: defaultcolor;
        }
    }
}
