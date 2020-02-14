using backendFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace backendFramework.Controllers
{
    public class TestController : ApiController
    {
        // GET: api/Test
        public IEnumerable<TestInfo> Get()
        {
            var ret = new TestInfo[1];

            var info = new TestInfo
            {
                BasicString = "string",
                BasicInt = 1000,
                BasicFloat = 3.14f,
                BasicDate = DateTime.Now,
                NotSentData = "This is not sent because of model"
            };

            ret[0] = info;

            return ret;

        }

        // GET: api/Test/5
        public TestInfo Get(int id)
        {
            return new TestInfo
            {
                BasicString = "Solo string",
                BasicInt = id,
                BasicFloat = 3.14f,
                BasicDate = DateTime.Now,
                NotSentData = "This is not sent because of model"
            };
        }

        /*// POST: api/Test
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }*/
    }
}
