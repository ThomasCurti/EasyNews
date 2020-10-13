using System;
using System.Collections.Generic;
using backendTestCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backendTestCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {

        private readonly ILogger<TestController> _logger;
        private readonly string TAG = "[Test]: ";

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        // GET: api/Test
        [HttpGet]
        public IEnumerable<TestInfo> Get()
        {
            _logger.LogInformation(TAG + "Getting information");

            var ret = new TestInfo[1];

            var info = new TestInfo
            {
                BasicString = "string",
                BasicInt = 1000,
                BasicFloat = 3.14f,
                BasicDate = DateTime.Now,
            };

            ret[0] = info;

            return ret;

        }

        // GET: api/Test/5
        [HttpGet("{id}", Name = "Get")]
        public TestInfo Get(int id)
        {
            _logger.LogInformation(TAG + "Getting " + id.ToString());

            return new TestInfo
            {
                BasicString = "Solo string",
                BasicInt = id,
                BasicFloat = 3.14f,
                BasicDate = DateTime.Now,
            };
        }

        /*// POST: api/Test
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/Test/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
