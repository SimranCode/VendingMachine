using System;

namespace VendingMachineProject
{
    public class Product
    {
        public static Item[] machine = { new Item("cola", 100), new Item("chips ", 50), new Item("candy", 65) };

        public static string howToSelect = Environment.NewLine + "Please select an item by typing the item's Selection Number:" + Environment.NewLine;
        public static string header = "item name | item price | Selection Number" + Environment.NewLine;
        private static Item selectedItem;
        public int userChoice = 0;

        private readonly VendingMachine vendingMachine;
        public Product(VendingMachine machine)
        {
            vendingMachine = machine;
        }

        public void DisplayProducts()
        {
            for (int i = 0; i < machine.Length; i++)
            {
                header += $"{machine[i].name} | ${machine[i].price / 100} | {i + 1}" + Environment.NewLine;
            }
            Console.WriteLine(howToSelect + header);
            header = "";
            int.TryParse(Console.ReadLine(), out userChoice);  
            MakeProductSelection();
        }

        public string MakeProductSelection()
        {
            var validSelection = false;
            string output = string.Empty;
            while (!validSelection)
            {
                if (userChoice - 1 < machine.Length && userChoice - 1 >= 0 && vendingMachine.CurrentAmount.Amount >= machine[userChoice - 1].price/100)
                {
                    selectedItem = machine[userChoice - 1];
                    vendingMachine.CurrentAmount.Amount = machine[userChoice - 1].price - vendingMachine.CurrentAmount.Amount;

                    vendingMachine.DisplayAmount(vendingMachine.CurrentAmount);
                    validSelection = true;
                     output = $"you have chosen {selectedItem.name}" + Environment.NewLine + "THANK YOU";

                }
                else
                {
                    validSelection = false;
                    int.TryParse(Console.ReadLine(), out userChoice);   
                    output = "the item number selected does not exist, please try again" ;

                }
            }
            return output;

        }
    }
}
