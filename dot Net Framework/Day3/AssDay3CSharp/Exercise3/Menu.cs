using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;



namespace Exercise3
{

    public class Menu
    {
       
        public List<string> Path;
        public List<string> Items;
        public Menu(List<string> path, List<string> items)
        {
            Path = path;
            Items = items;
        }

        public virtual void InitMenu()
        {
            var length = 60;
            var heights = 2 + Items.Count;
            var index = String.Join("->",Path);
            var left = "║                 ";
            var right = "                 ║";
            var dict = new Dictionary<string, string> {
                    {
                        "above",
                        "╔" + String.Concat(Enumerable.Repeat("═", length)) + "╗"},
                    {
                        "bottom",
                        "╚" + String.Concat(Enumerable.Repeat("═", length)) + "╝"},
                    {
                        "blank",
                        "║" + String.Concat(Enumerable.Repeat(" ", length)) + "║"},
                    {
                        "index",
                        index}};
            foreach (var i in Enumerable.Range(0, Items.Count))
            {
                var s = (i+1).ToString() + "." + Items[i];
                var l = length + 2 - left.Length - right.Length - s.Length;
                dict.Add((i+1).ToString(), left + s + String.Concat(Enumerable.Repeat(" ", l)) + right);
                
            }
            Console.WriteLine();
            Console.WriteLine(dict["index"]);
            foreach (var i in Enumerable.Range(0, heights - 0))
            {
                if (i == 0)
                {
                    Console.WriteLine(dict["above"] + "\n" + dict["blank"]);
                }
                else if (i == heights - 1)
                {
                    Console.WriteLine(dict["bottom"]);
                }
                else
                {
                    Console.WriteLine(dict[i.ToString()] + "\n" + dict["blank"]);
                }
            }
            
        }

       public virtual int Choice()
        {
            var count = 0;
            while (count < 3)
            {
                try
                {
                    Console.WriteLine("your choice :");
                    var choice = Convert.ToInt32(Console.ReadLine());
                    if (choice > Convert.ToInt32(Items.Count) || choice < 1)
                    {
                        Console.WriteLine("wrong input, try again!");
                        count += 1;
                        continue;
                    }
                    else
                    {
                        return choice;
                    }
                }
                catch
                {
                    Console.WriteLine("Valid input");
                    return -1;
                }
            }
            return -1;
        }
    }

    public class MainMenu : Menu
    {
    
        public static string Name =  "main menu" ;
        public MainMenu()
            :base(new List<string>(new string[] { Name }), new List<string>(new string[] { "start check in", "update check in detail", "history" }))
        {
            
            base.InitMenu();
        }
      

    }
   
    public class CategoryMenu : Menu
    {
        public static string Name = "Category Menu";
        public CategoryMenu()
            : base(new List<string>(new string[] { Name }), new List<string>(((CategoryType[])(Enum.GetValues(typeof(CategoryType)))).Select(c => c.ToString()).ToList()))
        {
            base.InitMenu();
            
        }

        

    }
    
}

 

