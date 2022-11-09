using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachineProject
{
    public class Coins
    {
        public Money dollarAmount = new Money("USD", 0);

        private readonly VendingMachine vendingMachine;
        public Coins(VendingMachine machine)
        {
            vendingMachine = machine;
        }

        public void AddCoins(Money money)
        {
            var amount = money.Amount;
            var currency = money.Currency;

            if (ValidCoin(currency))
            {
                ConvertToDollar(amount, currency, ref dollarAmount);
                vendingMachine.CurrentAmount.Amount += dollarAmount.Amount;
                vendingMachine.CurrentAmount.Currency = dollarAmount.Currency;
                vendingMachine.DisplayAmount(vendingMachine.CurrentAmount);
            }

        }

        private void ConvertToDollar(int amount, string currency, ref Money dollarAmount)
        {
            dollarAmount.Currency = "USD";
            if (currency == CoinType.Dimes.ToString())
                dollarAmount.Amount = amount / 10;
            else if (currency == CoinType.Nickels.ToString())
                dollarAmount.Amount = amount / 20;
            else if (currency == CoinType.Quarters.ToString())
                dollarAmount.Amount = amount / 4;
            else throw new ArgumentOutOfRangeException();
        }
        private bool ValidCoin(string currency)
        {
            Enum.TryParse(currency, out CoinType coinType);
            IEnumerable<CoinType> values = Enum.GetValues(typeof(CoinType))
                                .OfType<CoinType>()
                                .Select(s => s);
            if (values.Contains(coinType)) return true;           
            else return false;
        }
     
    }
}
