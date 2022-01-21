namespace Assignment.Presentation
{
    public class SelectLanguageCommand : ICommand
    {
        private GeolocationManager LanguagesService;

        public SelectLanguageCommand(GeolocationManager languages)
        {
            LanguagesService = languages;
        }

        public void execute()
        {
            LanguagesService.SelectLanguage();
        }
    }
}
