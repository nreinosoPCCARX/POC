using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebEx.Data;
using WebEx.Data.Repositories;
using WebEx.Interfaces.Models;

namespace DatabaseTester
{
    public class Program
    {
        public static void Main()
        {
            var repo = new EntityFrameworkRepository();

            repo.Add(new Person { FirstName = "Weeeeeeeeeeeeeeee" });

            for (int i = 0; i < 10000; i++)
            {
                foreach (var person in repo.GetAll<Person>().Where(p => p.IsCurrent))
                {
                    Console.WriteLine($"Persion Id = {person.Id}");

                    person.NickName = $"{i}___WEEEEEeeeeeee {DateTime.Now.ToString()}";

                    repo.Update(person);
                }
            }

            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
        }
    }
}
