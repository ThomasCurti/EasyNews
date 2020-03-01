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
            try
            {
                await Db.Connection.OpenAsync();
            }
            catch(Exception e)
            {
                //log
            }
            

            //create query
            var cmd = TestQuery.GetData(Db);

            //Read all data
            List<Test> values = new List<Test>();

            MySqlDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
            }
            catch(Exception e)
            {

            }
            
            while(reader.Read())
            {
                Object[] val = new Object[reader.FieldCount];
                reader.GetValues(val);

                //TODO Here call "<Model>.Parse" instead of this 
                values.Add(new Test
                {
                    ID = Int32.Parse(val[0].ToString()),
                    Value = Int32.Parse(val[1].ToString()),
                    Text = val[2].ToString(),
                    Boolean = bool.Parse(val[3].ToString()),
                });
            }

            await reader.DisposeAsync();
            await reader.CloseAsync();

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
            MySqlDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {

            }
            reader.Read();

            Object[] val = new Object[reader.FieldCount];
            reader.GetValues(val);
            
            //TODO Here call "<Model>.Parse" instead of this 
            test = new Test
            {
                ID = Int32.Parse(val[0].ToString()),
                Value = Int32.Parse(val[1].ToString()),
                Text = val[2].ToString(),
                Boolean = bool.Parse(val[3].ToString()),
            };


            await reader.DisposeAsync();
            await reader.CloseAsync();

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
