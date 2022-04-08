using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Account("Sheila Domínguez", 1000, 0);
            Console.WriteLine($"Accout has been created with number {account.Number} with an amout of ${account.Balance} by user {account.Owner}");

            var giftCard = new GiftCardAccount(account.Owner, 5000);
            giftCard.Deposit(200, DateTime.Now.AddDays(-4), "Regalo por apertura");
            giftCard.Deposit(500, DateTime.Now.AddDays(-2), "Ahorro voluntario");
            giftCard.Withdrawal(1500, DateTime.Now, "Pago colegiatura");
            //Console.WriteLine(giftCard.PrintHistory());

            var creditCard = new CreditAccount(account.Owner, 0, -2000);
            creditCard.Withdrawal(-1000, DateTime.Now.AddDays(-4), "Despensa");
            creditCard.Deposit(500, DateTime.Now.AddDays(-3), "Pago de Despensa");
            creditCard.Withdrawal(-1000, DateTime.Now.AddDays(-2), "Cena familiar");
            creditCard.Withdrawal(-800, DateTime.Now.AddDays(-1), "Ropa");
            creditCard.Corte();
            //Console.WriteLine(creditCard.PrintHistory());

            var investmentAccount = new InvestmentAccount(account.Owner, 150);
            investmentAccount.Deposit(100, DateTime.Now, "Depósito a Inversión");
            investmentAccount.Deposit(250, DateTime.Now, "Depósito a Inversión");
            investmentAccount.Withdrawal(-100, DateTime.Now, "Retiro de emergencia");
            investmentAccount.Deposit(200, DateTime.Now, "Depósito a Inversión");
            investmentAccount.ObtenerIntereses();
            Console.WriteLine(investmentAccount.PrintHistory());
        }
    }
}
