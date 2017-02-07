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

            repo.Add(new Person());

            foreach(var person in repo.GetAll<Person>())
            {
                Console.WriteLine($"Persion Id = {person.Id}");
            }

            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
        }
    }
}
