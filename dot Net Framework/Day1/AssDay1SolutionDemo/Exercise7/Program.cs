using System;

namespace Exercise7
{
    class Program
    {
        static void Main(string[] args)
        {
            Account a = new Account(123,(float)1000.0);
            Console.WriteLine("Enter Your PIN Number");

            if (a.CheckNumber(Convert.ToInt32(Console.ReadLine())))
            {
                
                menu( a);
            }
            
        }

        static void menu( Account a)
        {
            float cash;
            while (true)
            {
                Console.WriteLine("********Welcome to ATM Service**************\n1.Check Balance\n2.Withdraw Cash\n3.Deposit Cash\n4.Quit\n*********************************************");
                String choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        a.CheckBalance();
                        break;
                    case "2":
                        Console.WriteLine("How much?");
                        cash = Convert.ToSingle(Console.ReadLine());
                        a.Withdraw(cash);
                        break;
                    case "3":
                        Console.WriteLine("How much?");
                        cash = Convert.ToSingle(Console.ReadLine());
                        a.Deposit(cash);
                        break;
                    case "4":
                        Console.WriteLine("Bye!");
                        return;
                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
            }
           
        }
    }

    public class Account
    {
        private int number;
        private float balance;
        public Account(int number, float balance)
        {
            this.number = number;
            this.balance = balance;
        }

        public bool CheckNumber(int number)
        {
            return number == this.number;
        }

        public bool CheckBalance()
        {
            Console.WriteLine("Hello! Your balance is :"+Convert.ToString(this.balance));
            return true;
        }
        public bool Deposit(float cash)
        {
            this.balance += cash;
            Console.WriteLine("Successful!");
            return true;
        }

        public bool Withdraw(float cash)
        {
            if (cash < this.balance)
            {

                
                this.balance -= cash;
                Console.WriteLine("Successful!");
                return true;
            }
            Console.WriteLine("Sorry! Insuffient Fund!");
            return false;
        }
    }
}
