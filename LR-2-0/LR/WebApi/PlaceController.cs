using LR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LR.WebApi
{
    public class PlaceController : BasicController
    {
        // GET api/<controller>
        public IEnumerable<PlaceModel> Get()
        {
            return db.Places;
        }

        // GET api/<controller>/5
        public PlaceModel Get(Guid id)
        {
            return db.Places.Find(id);
        }

        // POST api/<controller>
        public void Post([FromBody]PlaceModel value)
        {
            if( string.IsNullOrEmpty(value.Name)) { throw new ArgumentNullException("missing name attribute."); }

            value.Id = Guid.NewGuid();

            db.Places.Add(value);
            db.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(Guid id, [FromBody]PlaceModel value)
        {
            if (id == null) { throw new ArgumentNullException("missing id attribute."); }
            if (string.IsNullOrEmpty(value.Name)) { throw new ArgumentNullException("missing name attribute."); }

            db.Places.Attach(value);
            var entry = db.Entry(value);
            entry.State = System.Data.Entity.EntityState.Modified;

            db.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(Guid id)
        {
            if (id == null) { throw new ArgumentNullException("missing id attribute."); }

            var value = db.Places.Find(id);
            var entry = db.Entry(value);
            entry.State = System.Data.Entity.EntityState.Deleted;

            db.SaveChanges();
        }
    }
}