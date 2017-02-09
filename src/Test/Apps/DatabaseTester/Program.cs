using System;
using WebEx.Data;
using WebEx.DbContextScope;
using WebEx.Interfaces.Models;

namespace DatabaseTester
{
    public class Program
    {
        public static void Main()
        {
            var factory = new DbContextScopeFactory();

            var repo = new EntityFrameworkRepository(new AmbientDbContextLocator());

            for (int i = 0; i < 1000; i++)
            {
                using (var scope = factory.Create())
                {
                    repo.Add(new Person { FirstName = "Weeeeeeeeeeeeeeee" });

                    foreach (var person in repo.GetAll<Person>())
                    {
                        Console.WriteLine($"Persion Id = {person.Id}");

                        person.NickName = $"{Guid.NewGuid()}___WEEEEEeeeeeee {DateTime.Now.ToString()}";
                    }
                }
            }

            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
        }
    }
}
