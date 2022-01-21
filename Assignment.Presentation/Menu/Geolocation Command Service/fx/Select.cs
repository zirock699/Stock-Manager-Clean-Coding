namespace Assignment.Presentation
{

    public class Select
    {


        private readonly ICommand command;

        public Select(ICommand command)
        {
            this.command = command;
        }

        public void SelectLanguage()
        {
            command.execute();
        }
        public void SelectCurrency()
        {
            command.execute();
        }






    }
}
