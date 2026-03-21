using System;

namespace problem_3
{
    
    class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message)
        {
        }
    }

    class BankAccount
    {
        private double balance;

        public BankAccount(double balance)
        {
            this.balance = balance;
        }

        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                throw new InsufficientBalanceException("Withdrawal amount exceeds available balance");
            }
            else
            {
                balance -= amount;
                Console.WriteLine("Withdrawal successful");
                Console.WriteLine("Remaining balance: " + balance);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Balance: ");
            double bal = double.Parse(Console.ReadLine());

            BankAccount acc = new BankAccount(bal);

            Console.Write("Enter Withdraw Amount: ");
            double amt = double.Parse(Console.ReadLine());

            try
            {
                acc.Withdraw(amt);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Transaction completed");
            }

            Console.ReadLine();
        }
    }
}