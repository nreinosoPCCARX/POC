using System;
using System.Diagnostics;
using System.Linq;
using WebEx.Components;
using WebEx.Data;
using WebEx.DbContextScope;
using WebEx.Interfaces.Models;

namespace DatabaseTester
{
    public class Program
    {
        public static void Main()
        {
            var sessionManager = new UserSessionManager();

            sessionManager.Loggin("Bob");

            var factory = new DbContextScopeFactory();

            var repo = new EntityFrameworkRepository(new AmbientDbContextLocator());

            for (int i = 0; i < 5; i++)
            {
                var sw = new Stopwatch();

                sw.Start();

                var counter = 0;

                using (var scope = factory.Create())
                {
                    repo.Add(new Person { FirstName = "Weeeeeeeeeeeeeeee" });

                    foreach (var person in repo.GetAll<Person>().Where(p => p.IsCurrent))
                    {
                        Console.WriteLine($"Persion Id = {person.Id}");

                        person.NickName = $"{Guid.NewGuid()}___WEEEEEeeeeeee {DateTime.Now.ToString()}";
                        counter++;
                    }
                }
                sw.Stop();

                Console.WriteLine($"Done with {counter} records in {sw.ElapsedMilliseconds} ms");
            }

            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
        }
    }
}
