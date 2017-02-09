using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Http;
using WebEx.API.MockData;
using WebEx.Interfaces.Models;
using WebEx.Interfaces.WebEx.Interfaces;

namespace WebEx.API.Controllers
{
    public class PeopleController : ApiController
    {
        IRepository repo = new MockDbContext();
        
        // GET: api/People
        public IEnumerable<Person> Get()
        {
            return repo.GetAll<Person>();
        }

        // GET: api/People/5
        public Person Get(long personId)
        {
            return repo.GetById<Person>(personId);
        }

        //// POST: api/People
        //public void Post([FromBody]string value)
        //{
        //}

        // GET: api/People/
        public IEnumerable<Person> FindPeopleByState(StateProvince state)
        {
            throw new NotImplementedException();
        }

        // PUT: api/People/5
        public void Put(long personId, [FromBody]Person person)
        {
            //repo.Update(person);
        }

        //// DELETE: api/People/5
        //public void Delete(int id)
        //{
        //}
    }
}
