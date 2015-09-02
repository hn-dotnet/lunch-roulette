using LR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace LR.WebApi
{
    public class BasicController : ApiController
    {
        internal Db db { get; set; }

        public BasicController()
        {
            db = new Db();
        }

    }
}
