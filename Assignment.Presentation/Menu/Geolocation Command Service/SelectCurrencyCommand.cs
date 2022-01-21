namespace Assignment.Presentation
{
    public class SelectCurrencyCommand : ICommand
    {
        private readonly GeolocationManager CurrenciesService;

        public SelectCurrencyCommand(GeolocationManager currencies)
        {
            CurrenciesService = currencies;
        }

        public void execute()
        {
            CurrenciesService.SelectCurrency();
        }
    }
}
