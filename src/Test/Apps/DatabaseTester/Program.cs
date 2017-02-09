using Ninject;
using System;
using System.Diagnostics;
using WebEx.DbContextScope.Interfaces;
using WebEx.Interfaces.Interfaces.Components;
using WebEx.Interfaces.Models;
using WebEx.Interfaces.WebEx.Interfaces;
using WebEx.IoC;

namespace DatabaseTester
{
    public class Program
    {
        public static void Main()
        {
            //set up IoC framework
            var booty = Bootstrapper.BuildKernel();
            var userSessionMgr = booty.Get<IUserSessionManager>();
            var factory = booty.Get<IDbContextScopeFactory>();
            var repo = booty.Get<IRepository>();

            for (int i = 0; i < 5; i++)
            {
                var counter = 0;
                userSessionMgr.Loggin($"Bob = {Guid.NewGuid()}");

                var sw = Stopwatch.StartNew();

                using (var scope = factory.Create())
                {
                    repo.Add(new Person { FirstName = "Weeeeeeeeeeeeeeee" });

                    foreach (var person in repo.GetAll<Person>(false, false))
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
