using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise3
{
    class AccountingSystem
    {
        public BaseTransaction Process()
        {
            string date;
            string description;
            string amount;
            BaseTransaction bs = new BaseTransaction();
            
            // try input date
            try
            {
                Console.WriteLine("Enter Transaction Date (YYYY/MM/DD) or Press Enter to skip");
                date = Console.ReadLine();
              
                if (date == null || date == "")
                {
                    
                   bs.Date = bs.GetDate(DateTime.Now.ToString("yyyy/MM/dd"));
                }
                else
                {
                    bs.Date = bs.GetDate(date);
                    if (bs.Date.Year > 3000 || bs.Date.Year < 1000) throw new System.FormatException();
                }
            }
            catch(Exception ex)
            {
                if(ex.GetType() == typeof(System.FormatException))
                {
                    Console.WriteLine("Please Enter Valid Date Format(YYYY/MM/DD)");
                }
                else
                {
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
            // try input description
            try
            {
                Console.WriteLine("Enter Transaction Description(not empty):");
                description = Console.ReadLine();
                if(description == "" || description == null)
                {
                    throw new System.FormatException();
                }
                else
                {
                    bs.Description = description;
                }
                
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(System.FormatException))
                {
                    Console.WriteLine("Not empty");
                }
                else
                {
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
            // try input amount and type
            try
            {
                Console.WriteLine("Enter Amount:");
                amount = Console.ReadLine();
                if (description == null)
                {
                    throw new System.FormatException();
                }
                else
                {
                    bs.Amount = Convert.ToDouble(amount);
                    bs.GetTransactionType();
                }

            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(System.FormatException))
                {
                    Console.WriteLine("Not empty");
                }
                else
                {
                    Console.WriteLine(ex.Message);
                }
                return null;
            }
            Menu m = new CategoryMenu();
            bs.Category = (CategoryType)m.Choice();
            return bs;

        }

        public void Filter(List<string> filters, List<BaseTransaction> transList)
        {
            
            IEnumerable<BaseTransaction> transQuery;
            if (filters.Contains("Category"))
            {
                CategoryType category;
                Menu m = new CategoryMenu();
                category = (CategoryType)m.Choice();
                transQuery =
                    from trans in transList
                    where trans.Category == category
                    select trans;
                transList = transQuery.ToList();

            }
            if (filters.Contains("Date"))
            {
                DateTime firstDate, secondDate;
                Console.WriteLine("Enter First Transaction Date (YYYY/MM/DD)");
                firstDate = DateTime.ParseExact(Console.ReadLine(), BaseTransaction.Pattern, null);
                Console.WriteLine("Enter Second Transaction Date (YYYY/MM/DD)");
                secondDate = DateTime.ParseExact(Console.ReadLine(), BaseTransaction.Pattern, null);
                transQuery =
                    from trans in transList
                    where trans.Date.Ticks >= firstDate.Ticks && trans.Date.Ticks<secondDate.Ticks
                    select trans;
                transList = transQuery.ToList();
            }
            if (filters.Contains("Text"))
            {
                Console.WriteLine("Enter Text Filter");
                string text = Console.ReadLine();
                
                transQuery =
                    from trans in transList
                    where trans.Description.IndexOf(text, StringComparison.OrdinalIgnoreCase) >= 0 && trans.Category.ToString().IndexOf(text, StringComparison.OrdinalIgnoreCase) >=0
                    select trans;
                transList = transQuery.ToList();
            }
            

            foreach (var t in transList)
            {
                int count = t.Description.Count(f => f == ' ');
                
                
                t.DisplayVertically();

            }
            Console.WriteLine("Total:" + transList.Count);

        }

        public List<BaseTransaction> GetSortedList(List<BaseTransaction> transList)
        {
            return (from trans in transList
                   orderby -trans.Date.Ticks, trans.Description
                   select trans).ToList();
        }
    }
}
