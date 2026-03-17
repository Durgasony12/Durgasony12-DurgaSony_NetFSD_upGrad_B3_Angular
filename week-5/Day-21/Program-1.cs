using System;

namespace problem_1
{
    class BankAccount
    {
       private int accountNumber;
       private double balance;

        
        public int AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        public double Balance
        {
            get { return balance; }
        }

        
        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid deposit amount");
                return;
            }

            balance += amount;
            Console.WriteLine("Deposit Successful");
            Console.WriteLine("Current Balance = " + balance);
        }

        
        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid withdrawal amount");
                return;
            }

            if (amount > balance)
            {
                Console.WriteLine("Insufficient Balance");
                return;
            }

            balance -= amount;
            Console.WriteLine("Withdrawal Successful");
            Console.WriteLine("Current Balance = " + balance);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount acc = new BankAccount();

            acc.AccountNumber = 12345;

            acc.Deposit(5000);
            acc.Withdraw(2000);

            Console.WriteLine("Final Balance = " + acc.Balance);
        }
    }
}
