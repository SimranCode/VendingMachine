namespace VendingMachineProject
{
    public class VendingMachine
    {
        public  Money CurrentAmount { get; set; }

        public VendingMachine()
        {
            CurrentAmount = new Money("USD", 0);
            InitializeMachine();
        }
        private string InitializeMachine()
        {
            return "INSERT COIN";
        }

        public  string DisplayAmount(Money currentAmount)
        {
            return string.Format(@"Current Amount: {0}", currentAmount);
        }

    }
}
