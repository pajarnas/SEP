using System;
using System.Collections.Generic;
using System.Text;
using Data.Repository;
using Data.Model;
using System.Linq;
using System.Globalization;

namespace AssDay5ADO.Net
{
    public class ManageExercise
    {
        public void Run()
        {
            //Exercise1();
            //Exercise2();
            // Exercise3();
            // Exercise5();
            //Exercise6();
            // Exercise7();

            //Exercise8();
            Exercise9();
        }

        public void Exercise2()
        {
            VillainRepository villainRepository = new VillainRepository();
            var aList = villainRepository.GetAllVillainsWithMinionsWithName();
            foreach (var item in aList)
            {
                Console.WriteLine($"{item}");

            }
        }

        public void Exercise3()
        {
            VillainRepository villainRepository = new VillainRepository();
            Console.WriteLine("Enter Villain Id");
            int id = Convert.ToInt32(Console.ReadLine());
            var aList = villainRepository.GetAllMinionNameAndAgeByVillainId(id);
            foreach (var item in aList)
            {
                Console.WriteLine($"{item}");

            }
            Console.ReadKey();
        }

        public void Exercise4()
        {
            // Declare repositories
            MinionRepository minionRepository = new MinionRepository();
            TownRepository townRepository = new TownRepository();
            VillainRepository villainRepository = new VillainRepository();

            //Promote the towns
            foreach (var item in townRepository.GetAll())
            {
                Console.WriteLine($"Id : {item.Id}\t Name: {item.Name}");
            }

            //Get the Minion data
            Console.WriteLine("Enter Minion Info:Name-Age-TownName");
            string line = Console.ReadLine();
            var minionLines = line.Split('-');
            Town town = townRepository.GetByName(minionLines[2]);
            //if town does not exist condition
            if(town == null)
            {
                town = new Town();
                town.Name = minionLines[2];
                town.CountryId = 1;
                townRepository.Insert(town);
                town = townRepository.GetByName(town.Name);
                Console.WriteLine($"Town {town.Name} was added to the database.");
            }
            //Read info of its villain
            Console.WriteLine("Enter Villain Name");
            string villainName = Console.ReadLine();
            Villain villain = villainRepository.GetByName(villainName);
            //if town does not exist condition
            if (villain == null)
            {
                villain = new Villain();
                villain.Name = villainName;
                villain.EvilnessFactorId = 3;
                villainRepository.Insert(villain);
                villain = villainRepository.GetByName(villain.Name);
                Console.WriteLine($"Villain  {villain.Name} was added to the database.");
            }
            Minion minion = new Minion();
            minion.Name = minionLines[0];
            minion.Age = Convert.ToInt32(minionLines[1]);
            minion.TownId = town.Id;
            minionRepository.Insert(minion);
            minion = minionRepository.GetByName(minion.Name);
            if(RelationshipsRepository.AddNewMinionToVillain(minion, villain) > 0)
            {
                Console.WriteLine($"Successfully added {minion.Name} to be minion of {villain.Name}.");
            }

            Console.ReadKey();
        }

        public void Exercise5()
        {
            CountryRepository countryRepository = new CountryRepository();
            TownRepository townRepository = new TownRepository();
            foreach (var item in countryRepository.GetAll())
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine("Enter Country Name => ");
            string countryName = Convert.ToString(Console.ReadLine());
            Country country = countryRepository.GetByName(countryName);
            IEnumerable<Town> towns = townRepository.GetAllByCountry(country);
            List<Town> townList = new List<Town>(towns);
            if (townList.Count == 0)
            {
                Console.WriteLine("No town names were affected.");
                return;
            }
            Console.WriteLine(townList.Count + "town names were affected. ");
            foreach (var item in towns)
            {
                item.Name = item.Name.ToUpper();
                townRepository.Update(item);
                Console.Write(item.Name+",");
            }
            Console.WriteLine(); 
        }

        public void Exercise6()
        {
            VillainRepository villainRepository = new VillainRepository();
            MinionRepository minionRepository = new MinionRepository();
            List<Villain> villains = new List<Villain>(villainRepository.GetAll());
            foreach (var item in villains)
            {
                Console.WriteLine(item.Id + " " + item.Name);
            }
            Console.WriteLine("Enter id of a villain to delete:");
            int id = Convert.ToInt32(Console.ReadLine());
            Villain v = villainRepository.GetById(id);
            if (v == null)
            {
                Console.WriteLine("No such villain found");
                return;
            }
            int r = RelationshipsRepository.DeleteMinionsOfVillain(v);
            
            villainRepository.Delete(id);
            Console.WriteLine(v.Name + " was deleted.");
            Console.WriteLine(r+" minions were released.");
            return;
           

        }

        public void Exercise7()
        {
            MinionRepository minionRepository = new MinionRepository();
            List<Minion> minions = new List<Minion>(minionRepository.GetAll());
            Minion first;
            while (minions.Any())
            {
                first = minions.FirstOrDefault();
                Console.WriteLine(first.Name);
                minions.Remove(first);
                minions.Reverse();
            }
        }

        public void Exercise8()
        {
            MinionRepository minionRepository = new MinionRepository();
            List<Minion> minions = new List<Minion>(minionRepository.GetAll());
            foreach (var item in minions)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Age);
            }
            Console.WriteLine("Enter IDs separated by space");
           
            var idList = Console.ReadLine().Split(" ").ToList<string>().Select(int.Parse).ToList() ;
            foreach (var item in idList)
            {
                Minion m = minionRepository.GetById(item) ;
                m.Age++;
                m.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(m.Name);
                minionRepository.Update(m);
            }
            minions = new List<Minion>(minionRepository.GetAll());
            foreach (var item in minions)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Age);
            }
      
        }

        public void Exercise9()
        {
            MinionRepository minionRepository = new MinionRepository();
            List<Minion> minions = new List<Minion>(minionRepository.GetAll());
            foreach (var item in minions)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Age);
            }
            Console.WriteLine("Enter IDs separated by space");

            var idList = Console.ReadLine().Split(" ").ToList<string>().Select(int.Parse).ToList();
            foreach (var item in idList)
            {
                minionRepository.GetOlder(item);
            }
            minions = new List<Minion>(minionRepository.GetAll());
            foreach (var item in minions)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Age);
            }
        }
    }
}
