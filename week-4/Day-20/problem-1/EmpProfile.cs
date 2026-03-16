using System;
using System.Collections.Generic;
using System.Text;

namespace Employee
{
    internal class Employee
    {
        private string _name;
        private decimal _salary;
        private int _age;
        public int _EmpID;
        public string Name
        {
            get {  return _name; }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Account Holder Name cannot be empty");
                }
                _name=value;
            }
        }
        public int Age
        {
            get { return _age; }
            set
            {
                if(value < 18 || value > 80)
                {
                    throw new ArgumentException("Enter age > 18 and < 80");
                }
                _age = value;
            }
        }
        public decimal Salary
        {
            get{ return _salary; }
            private set
            {
                if (value < 1000)
                {
                    throw new ArgumentException("salary should be minimum 1000");
                }
                _salary = value;
            }
        }
        public int EmployeeID
        {
            get { return _EmpID; }
        }
        public Employee(string name, decimal salary, int age, int empID = 1)
        {
            //property setters
            Name=name;
            Salary=salary; 
            Age=age;

        }
        public void GiveRise(decimal percentage)
        {
            if(percentage < 0 || percentage > 30)
            {
                throw new ArgumentException("Inavlid percentage");
            }
            decimal bonus= _salary* (percentage/100);
            _salary += bonus;
            Console.WriteLine($"The salary increase: {percentage}%");
            Console.WriteLine($"Updated slary: {_salary}");
        }
        public bool DeductPenalty(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Penalty must be greater than zero");
            }

            if ((_salary - amount) < 1000)
            {
                return false;
            }
            Salary = _salary - amount;

            Console.WriteLine($"Penalty deducted : {amount}");
            Console.WriteLine($"Salary after deduction : {Salary}");

            return true;

        }

    }
}
