using System;
using System.Collections.Generic;
namespace Exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
    
            AccountingSystem a = new AccountingSystem();
            //Add expense
            /*BaseTransaction bs = a.Process();
            if(bs != null)
            {
                bs.Display();
            }*/
           
            List<string> filters = new List<string> {"Category","Date" };
            List<BaseTransaction> trans = new List<BaseTransaction>(); 
            for (int i = 0; i < 70; i++)
            {
                BaseTransaction b = new BaseTransaction();
                b.InitRandomly();
                trans.Add(b);
            }

            // Filter by Date and Category
            // a.Filter(filters, trans);

            List<string> filters2 = new List<string> { "Text" };
            
            //Filter by TEXT

            //a.Filter(filters2, trans);

            //sort  
            Console.WriteLine("Get Sorted List");
            foreach(BaseTransaction o in a.GetSortedList(trans))
            {
                o.DisplayVertically();
            }




        }
    }
}
