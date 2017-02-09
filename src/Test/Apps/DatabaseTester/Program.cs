using Ninject;
using System;
using System.Diagnostics;
using System.Linq;
using WebEx.Data;
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

            for (int i = 0; i < 2; i++)
            {
                var counter = 0;
                userSessionMgr.Loggin($"Bob = {Guid.NewGuid()}");

                var sw = Stopwatch.StartNew();

                using (var scope = factory.Create())
                {
                    var repo = scope.DbContexts.GetRepository<ExDataContext>();
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

            userSessionMgr.Loggin($"Bob Unarchive");

            using (var scope = factory.Create())
            {
                var repo = scope.DbContexts.GetRepository<ExDataContext>();
                var bob = repo.Find<Person>(c => !c.IsCurrent).FirstOrDefault();

                if(bob!= null)
                {
                    repo.Unarchive(bob);
                }
            }

            using (var scope = factory.Create())
            {
                var repo = scope.DbContexts.GetRepository<ExDataContext>();
                var bob = repo.GetAll<Person>(false, false).FirstOrDefault();

                if (bob != null)
                {
                    repo.Remove(bob);
                }
            }

            using (var scope = factory.Create())
            {
                var repo = scope.DbContexts.GetRepository<ExDataContext>();
                var bob = repo.Find<Person>(c => c.IsRemoved, true).FirstOrDefault();

                if (bob != null)
                {
                    repo.Replace(bob);
                }
            }

            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
        }
    }
}
