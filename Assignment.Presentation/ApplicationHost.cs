using Assignment.Application.Contracts;
using Assignment.Contracts;
using Assignment.Presentation;
using Assignment.Presentation.Actions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment
{
    public class ApplicationHost
    {
        private readonly int EXIT = Menu.GetMenu()["EXIT"].ItemNumber;
        private readonly IDataSeederService _dataSeederService;
        private readonly IConsoleReader _consoleReader;
        private readonly IEnumerable<IActionStrategy> _actionStrategies;
        public static string Currency { get; private set; }
        public static string Language { get; private set; }

        public ApplicationHost(IDataSeederService dataSeederService, IConsoleReader consoleReader, IEnumerable<IActionStrategy> actionStrategies)
        {

            _dataSeederService = dataSeederService;
            _consoleReader = consoleReader;
            _actionStrategies = actionStrategies;


        }

        public void Run()
        {
           
            var geolocationService = new GeolocationManager();
            var LanguageCommand = new SelectLanguageCommand(geolocationService);
            var CurrencyCommand = new SelectCurrencyCommand(geolocationService);
            var selectLanguage = new Select(LanguageCommand);
            var selectCurrency = new Select(CurrencyCommand);
            selectCurrency.SelectCurrency();
            selectLanguage.SelectLanguage();
            Currency = geolocationService.GetCurrecy();
            Language = geolocationService.GetLanguage();

            _dataSeederService.Seed();

            Menu.Loading(Job: "Loading database", Message: "Database Loaded");

            DisplayMenu();

            int option = GetUserChoice(); 
            while (!option.Equals(EXIT))
            {
                var strategy = _actionStrategies.Where(x => x.ActionType == option)
                                    .SingleOrDefault();
                if (strategy == null) Console.WriteLine("Option not recognized!");
                else
                {
                    strategy.Excute();
                }

                DisplayMenu();
                option = GetUserChoice();

            }
        }

        private static void DisplayMenu()
        {
            

            foreach (var MenuOption in Menu.GetMenu())
            {

                if (MenuOption.Value.ItemName.Equals("EXIT"))
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                Console.WriteLine("{0}. {1}.",
                    MenuOption.Value.ItemNumber,
                    Menu.GetItemDisplayText(Lang: Language,
                                            ItemID: MenuOption.Key));
                Console.ResetColor();
            }
        }

        private int GetUserChoice()
        {
            int option = _consoleReader.ReadInteger("\nOption");
            bool validOption = Menu.AvailableOptions().Contains(option);

            while (!validOption)
            {
                Console.WriteLine("\nChoice not recognised, Please enter again");
                option = _consoleReader.ReadInteger("\nOption");
                validOption = Menu.AvailableOptions().Contains(option);
            }
            return option;
        }
    }
}
