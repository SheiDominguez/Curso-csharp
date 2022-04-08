using System;
namespace BankApp
{
    public class InvestmentAccount : Account
    {
        public InvestmentAccount(string name, decimal initialBalance) : base(name, initialBalance, 0)
        {
        }

        public void ObtenerIntereses()
        {
            if(Balance > 500)
            {
                decimal interes = Balance * 0.05m;
                Deposit(interes, DateTime.Now, "Pago de interés");
            }
        }
    }
}
