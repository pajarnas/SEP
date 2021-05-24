using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Exercise3
{
    enum CategoryType
    {
        Other = 1,
        [Display(Name = "Transportation")]
        Transportation,
        Restaurant,
        Hotel,
        [Display(Name = "Education Expense")]
        EducationExpense,
        [Display(Name = "Medical Expense")]
        MedicalExpense,
        
    }

    enum TransactionType
    {
        Income,
        Expense
    }
    class BaseTransaction
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public CategoryType Category { get; set; }
        public double Amount { get; set; }

        public const string Pattern = "yyyy/MM/dd";

        public TransactionType Type { get; set; }

        public DateTime GetDate(string sourceDateText)
        {
         
            return DateTime.ParseExact(sourceDateText, BaseTransaction.Pattern, null);
            
        }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("Success!~");
            Console.WriteLine("Amount:\t\t\t" + String.Format("{0:C}", Math.Round( Amount, 2)));
            Console.WriteLine("Category:\t\t" +  Category);
            Console.WriteLine("Date:\t\t\t" +  Date.ToString(BaseTransaction.Pattern));
            Console.WriteLine("Description:\t\t" +  Description);
            Console.WriteLine("Type:\t\t\t" +  Type);
        }

        public void DisplayVertically()
        {
            
            Console.Write("Amount:" + String.Format("{0:C}", Math.Round(Amount, 2)));
            Console.Write("\t\t\t-(Category:" + Category);
            Console.Write("\t\t\t-Date:" + Date.ToString(BaseTransaction.Pattern));
            Console.Write("\t\t-Description:" + Description);
            Console.WriteLine("\t)");
            Console.WriteLine();
        }

        public void GetTransactionType()
        {
            if (Amount > 0)
            {
                Type = TransactionType.Income;
                return;
            }
            Type =  TransactionType.Expense;
        }
        
        public void InitRandomly()
        {
            var rand = new Random();
            Category = (CategoryType)rand.Next(1, 7);
            Amount = (double)rand.Next(-2000, 4001)+  Math.Round(rand.NextDouble(),2);
            GetTransactionType();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz    ";
            Description = new string(Enumerable.Repeat(chars, 10)
              .Select(s => s[rand.Next(s.Length)]).ToArray());
            DateTime start = new DateTime(1995, 1, 1);
            int range = (DateTime.Today - start).Days;
            Date = start.AddDays(rand.Next(range));
        }
      
    }
}
