using System;
using System.Text;

namespace BankApp
{
    public class CreditAccount : Account
    {
        public CreditAccount(string name, decimal initialBalance, int creditLimit): base(name, initialBalance, -creditLimit)
        {
        }

        public void Corte()
        {
            if (Balance < 0)
            {
                decimal interes = -Balance * 0.07m;
                Withdrawal(interes, DateTime.Now, "Cobro de interés");
            } 
        }

        protected override Transaction CheckWithdrawalLimit(bool isOverChange)
        {
            if (isOverChange)
            {
                return new Transaction(-20,DateTime.Now, "Cargo por sobregiro");
            }
            else
                return default; // --> Regresa el valor por defecto de la variable de retorno
        }
    }
}
