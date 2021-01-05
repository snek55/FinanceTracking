namespace FinanceTracking.Shared.MainPage
{
    using Entities;
    using Extensions;

    public partial class EditFormMainPage
    {
        private readonly Shopping _shopping = new();

        private void HandleValidSubmit()
        {
            // TODO: проверка валидации
            new TableMainPage().AddTableListElement(this._shopping);
        }
    }
}