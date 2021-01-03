using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace FinanceTracking.Pages
{
    public partial class ColorPicker
    {
        private string defaultcolor = "#ffffff";
        private string commBackgroundColor;
        private string fontBackgroundColor;
        private string fontForegroundColor;

        [Inject]
        private ISyncLocalStorageService localStorage { get; set; }
        public string CommBackgroundColor
        {
            get => GetFromLocalStorage(nameof(CommBackgroundColor));
            set
            {
                commBackgroundColor = value;
                UpdateLocalStorage(nameof(CommBackgroundColor), value);
            }
        }
        private string FontBackgroundColor 
        {
            get => GetFromLocalStorage(nameof(FontBackgroundColor));
            set 
            { 
                fontBackgroundColor = value; 
                UpdateLocalStorage(nameof(FontBackgroundColor),value); 
            }
        }
        private string FontForegroundColor 
        {
            get => GetFromLocalStorage(nameof(FontForegroundColor));
            set
            {
                fontForegroundColor = value;
                UpdateLocalStorage(nameof(FontForegroundColor), value);
            }
        }

        private void UpdateLocalStorage(string k, string v)
        {
            localStorage.SetItem(k, v);
        }

        private string GetFromLocalStorage(string k)
        {
            if(localStorage.ContainKey(k))
                return localStorage.GetItem<string>(k).ToString();
            return defaultcolor;
        }
    }
}
