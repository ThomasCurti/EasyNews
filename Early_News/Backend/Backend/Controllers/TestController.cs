using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.DataAccess;
using Backend.Dbo;
using Backend.Model;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private AppDb Db { get; }

        public TestController(AppDb db)
        {
            Db = db;
        }



        // GET: api/Test
        [HttpGet]
        public async Task<IEnumerable<Object>> Get()
        {
            //open connection
            await Db.Connection.OpenAsync();

            //create query
            var cmd = TestQuery.GetData(Db);

            //Read all data
            List<Test> values = new List<Test>();

            using(var reader = cmd.ExecuteReader())
            {
                while(reader.Read())
                {
                    Object[] val = new Object[reader.FieldCount];
                    reader.GetValues(val);

                    values.Add(new Test
                    {
                        ID = Int32.Parse(val[0].ToString()),
                        Value = Int32.Parse(val[1].ToString()),
                        Text = val[2].ToString(),
                        Boolean = bool.Parse(val[3].ToString()),
                    });
                }

            }

            return values;
        }

        // GET: api/Test/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Test> Get(uint id)
        {
            //open connection
            await Db.Connection.OpenAsync();

            //create query
            var cmd = TestQuery.GetData(id, Db);

            //Read all data

            Test test;
            using (var reader = cmd.ExecuteReader())
            {
                reader.Read();

                Object[] val = new Object[reader.FieldCount];
                reader.GetValues(val);

                test = new Test
                {
                    ID = Int32.Parse(val[0].ToString()),
                    Value = Int32.Parse(val[1].ToString()),
                    Text = val[2].ToString(),
                    Boolean = bool.Parse(val[3].ToString()),
                };

            }

            return test;
        }

        /*// POST: api/Test
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Test/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
