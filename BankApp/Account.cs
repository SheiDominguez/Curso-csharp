using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public class Account
    {
        public string Owner { get; set; }
        public string Number { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach(var transaction in transactionList)
                {
                    balance += transaction.Amount;
                }
                return balance;
            }
        }
        public List<Transaction> transactionList = new List<Transaction>();
        private readonly int _minimumBalance;
        private static int accounNumberSeed = 1234567890;

        public Account(){}

        //public Account(string name, decimal initialBalance) : this(name, initialBalance, 0);

        public Account(string name, decimal initialBalance, int minimumBalance)
        {
            Owner = name;
            _minimumBalance = minimumBalance;
            Number = accounNumberSeed.ToString();
            accounNumberSeed++;

            if (initialBalance > 0)
                Deposit(initialBalance, DateTime.Now, "Balance inicial");
        }

        public void Deposit(decimal amount, DateTime date, string description)
        {
            if (amount <= 0)
                Console.WriteLine("Deposit must be greater than 0");

            var deposit = new Transaction(amount, date, description);
            transactionList.Add(deposit);
        }

        public void Withdrawal(decimal amount, DateTime date, string description)
        {
            if (amount <= 0)
                Console.WriteLine("");

            var transaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);
            var withdrawal = new Transaction(amount, date, description);
            transactionList.Add(withdrawal);

            if (transaction != null)
                transactionList.Add(transaction);
        }

        protected virtual Transaction CheckWithdrawalLimit(bool isOverChange)
        {
            if (isOverChange)
                throw new InvalidOperationException("Not enought founds.");
            else
                return default; // --> Regresa el valor por defecto de la variable de retorno
        }

        public string PrintHistory()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("********** MOVEMENTS **********").Append("\n");
            sb.Append("Date\t\tDescription\t\tAmount\n");

            transactionList.ForEach(transacc =>
            {
                sb.Append(transacc.Date.ToString("dd/MM/yyy")).Append("\t");
                sb.Append(transacc.Description).Append("\t");
                sb.Append("$").Append(transacc.Amount).Append("\n");
            });

            return sb.ToString();
        }
    }
}
