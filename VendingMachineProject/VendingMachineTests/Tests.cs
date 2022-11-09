using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace VendingMachineProject.VendingMachineTests
{

    [TestClass]
    public class Tests
    {

        [TestMethod]
        public void User_Should_Be_Able_To_Add_Coins()
        {
            var money = new Money("Nickels", 20);
            var machine = new VendingMachine();
            var coins = new Coins(machine);
            coins.AddCoins(money);
            Assert.AreEqual(machine.CurrentAmount.Amount, money.Amount / 20);
            Assert.AreEqual(machine.CurrentAmount.Currency, "USD");

        }
        [TestMethod]
        public void User_Should_Be_Able_To_Make_Product_Selection()
        {
            var output = "youhavechosenchipsTHANKYOU";
            var money = new Money("Nickels", 20);
            var machine = new VendingMachine();
            var coins = new Coins(machine);
            coins.AddCoins(money);
            var product = new Product(machine);
            product.userChoice = 2;
            var result = string.Concat(product.MakeProductSelection().Where(c => !Char.IsWhiteSpace(c)));


            Assert.AreEqual(output, result);

        }

       
    }
}
