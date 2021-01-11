using Microsoft.AspNetCore.Components;
using Blazored.LocalStorage;

namespace FinanceTracking.Pages
{
    public partial class ColorPicker
    {
        private string defaultcolor = "#ffffff";

        [Inject]
        private ISyncLocalStorageService localStorage { get; set; }

        private string CommBackgroundColor
        {
            get => GetFromLocalStorage(nameof(CommBackgroundColor));
            set => UpdateLocalStorage(nameof(CommBackgroundColor), value);
        }

        private string FontBackgroundColor 
        {
            get => GetFromLocalStorage(nameof(FontBackgroundColor));
            set => UpdateLocalStorage(nameof(FontBackgroundColor),value); 
        }

        private string FontForegroundColor 
        {
            get => GetFromLocalStorage(nameof(FontForegroundColor));
            set => UpdateLocalStorage(nameof(FontForegroundColor), value);
        }

        private void UpdateLocalStorage(string k, string v)
        {
            localStorage.SetItem(k, v);
        }

        private string GetFromLocalStorage(string k)
        {
            return localStorage.ContainKey(k)? localStorage.GetItem<string>(k): defaultcolor;
        }
    }
}
