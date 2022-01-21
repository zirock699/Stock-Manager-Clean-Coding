using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Assignment.Presentation
{

    public static class Menu
    {

        /// <summary>
        /// list of menu items
        /// </summary>
        private static readonly Dictionary<string, MenuItem> MenuList = new Dictionary<string, MenuItem>()
        {
            { "ADD_ITEM_TO_STOCK",
                new MenuItem { 
                    ItemNumber=1,
                    ItemName ="ADD_ITEM_TO_STOCK",
                    EngItemDisplayText="Add Item To stock",
                    FRItemDisplayText="Ajouter un article au stock"  } 
            },
            { "ADD_QUANTITY_TO_ITEM",
                new MenuItem { 
                    ItemNumber=2,
                    ItemName ="ADD_QUANTITY_TO_ITEM",
                    EngItemDisplayText="Add Quantity to item",
                    FRItemDisplayText="Ajouter la quantité à l'article" } 
            },
            { "TAKE_QUANTITY_FROM_ITEM",
                new MenuItem { 
                    ItemNumber=3,
                    ItemName ="TAKE_QUANTITY_FROM_ITEM",
                    EngItemDisplayText="Take quantity from item" ,
                    FRItemDisplayText="Prendre la quantité de l'article" } 
            },
            { "VIEW_INVENTORY_REPORT",
                new MenuItem {
                    ItemNumber=4,
                    ItemName ="VIEW_INVENTORY_REPORT",
                    EngItemDisplayText="View inventory report",
                    FRItemDisplayText="Afficher le rapport d'inventaire"  } 
            },
            { "VIEW_FINANCIAL_REPORT",
                new MenuItem { 
                    ItemNumber=5,
                    ItemName ="VIEW_FINANCIAL_REPORT",
                    EngItemDisplayText="View financial report" ,
                    FRItemDisplayText="Consulter le rapport financier" } 
            },
            { "VIEW_TRANSACTION_LOG",
                new MenuItem { 
                    ItemNumber=6,
                    ItemName ="VIEW_TRANSACTION_LOG",
                    EngItemDisplayText="View transaction log" ,
                    FRItemDisplayText="Afficher le journal des transactions" } 
            },
            { "VIEW_PERSONAL_USAGE_REPORT",
                new MenuItem { 
                    ItemNumber=7,
                    ItemName ="VIEW_PERSONAL_USAGE_REPORT",
                    EngItemDisplayText="View personal usage report",
                    FRItemDisplayText="Afficher le rapport d'utilisation personnel" } 
            },
            { "EXIT",
                new MenuItem {
                    ItemNumber=8,
                    ItemName ="EXIT", 
                    EngItemDisplayText="EXIT" ,
                    FRItemDisplayText="SORTIR"} 
            }
        };


        public static Dictionary<string, MenuItem> GetMenu()
        {
            return MenuList;
        }

        public static string GetItemDisplayText(string Lang, string ItemID)
        {

            return Lang.Equals("Eng") ? MenuList[ItemID].EngItemDisplayText : MenuList[ItemID].FRItemDisplayText;
        }

        public static List<int> AvailableOptions()
        {
            List<int> AvaialbleOptions = new List<int>();

            foreach (var MenuItem in Menu.GetMenu())
            {
                AvaialbleOptions.Add(MenuItem.Value.ItemNumber);

            }

            return AvaialbleOptions;
        }


        public static void Loading(string Job, string Message)
        {
            Console.Write(Job);
            var Millisecond = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(Millisecond.Next(0, 1000));

            }
            Console.Write("\n{0}", Message);
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
        }

        public static void LoadJson()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\Hichem\OneDrive - Staffordshire University\Clean coding\Drafts\CCCP V2\Assignment1_StartingPoint_Improved\Assignment.Presentation\Menu\MenuContent.json"))
            {
                string json = r.ReadToEnd();

                Dictionary<string, string>  list = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

                foreach (var item in list)
                {
                    Console.WriteLine(item.Value);
                }

            }
        }
    }
}
