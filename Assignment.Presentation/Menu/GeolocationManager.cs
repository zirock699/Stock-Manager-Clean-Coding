using System;

namespace Assignment.Presentation
{
    public class GeolocationManager
    {
        private string _Languages { get; set; }
        private string _Currency { get; set; }

        public string GetCurrecy()
        {
            return _Currency;
        }
        public void SetCurrency(string currency)
        {
            _Currency = currency;

        }
        public void SelectCurrency()
        {
            var print = "Please select currency (Default ";

            foreach (Currencies Options in Enum.GetValues(typeof(Currencies)))
            {
                print += Options + "/";
            }
            print = print.Remove(print.Length - 1, 1);
            print = string.Format("{0}): ", print);

            Console.Write(print);


            string Currency = Console.ReadLine();
            if (IsValidCurrency(Currency))
            {
                SetLanguage(Currency);
                Loading(Job: "Setting up Currency", Message: "Currency set.");
            }
            else
            {
                SetLanguage(default(Currencies).ToString());
                Console.WriteLine("Invalid input! Default language ({0}) Selected.", default(Currencies).ToString());
                Loading(Job: "Loading Application", Message: "Application Loaded");
            }
        }

        private bool IsValidCurrency(string currency)
        {
            return Enum.IsDefined(typeof(Currencies), currency); ;
        }

        public string GetLanguage()
        {
            return _Languages;

        }

        public void SetLanguage(string language)
        {
            _Languages = language;

        }

        public void SelectLanguage()
        {
            var print = "Please select menu language (Default ";

            foreach (Languages Options in Enum.GetValues(typeof(Languages)))
            {
                print += Options + "/";
            }
            print = print.Remove(print.Length - 1, 1);
            print = string.Format("{0}): ", print);

            Console.Write(print);


            string Language = Console.ReadLine();
            if (!IsValidLangage(Language))
            {
                SetLanguage(default(Languages).ToString());
                Console.WriteLine("Invalid input! Default language ({0}) Selected.", default(Languages).ToString());

                Loading(Job: "Loading Application", Message: "Application Loaded");
            }
            else
            {
                SetLanguage(Language);
                Loading(Job: "Loading Application", Message: "Application Loaded");
            }
        }
        private bool IsValidLangage(string Language)
        {
            return Enum.IsDefined(typeof(Languages), Language); ;
        }



        public void Loading(string Job, string Message)
        {
            Console.Write(Job);
            var Millisecond = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(Millisecond.Next(0, 500));

            }
            Console.Write("\n{0}", Message);
            System.Threading.Thread.Sleep(500);
            Console.Clear();
        }
    }
}
