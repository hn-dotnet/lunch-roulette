using LR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LR.WebApi
{
    public class UserController : BasicController
    {
        // GET api/<controller>
        public IEnumerable<UserModel> Get()
        {
            return db.Users;
        }

        // GET api/<controller>/5
        public UserModel Get(Guid id)
        {
            return db.Users.Find(id);
        }

        // POST api/<controller>
        public void Post([FromBody]UserModel value)
        {
            if (string.IsNullOrEmpty(value.Email)) { throw new ArgumentNullException("missing email attribute."); }
            if (value.Time == null) { throw new ArgumentNullException("missing place attribute."); }

            value.Id = Guid.NewGuid();

            db.Users.Add(value);
        }

        // PUT api/<controller>/5
        public void Put(Guid id, [FromBody]UserModel value)
        {
            if (id == null) { throw new ArgumentNullException("missing id attribute."); }
            if (string.IsNullOrEmpty(value.Email)) { throw new ArgumentNullException("missing email attribute."); }
            if (value.Time == null) { throw new ArgumentNullException("missing place attribute."); }

            db.Users.Attach(value);
            var entry = db.Entry(value);
            entry.State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(Guid id)
        {
            if (id == null) { throw new ArgumentNullException("missing id attribute."); }

            var value = db.Users.Find(id);
            var entry = db.Entry(value);
            entry.State = System.Data.Entity.EntityState.Deleted;

            db.SaveChanges();
        }
    }
}