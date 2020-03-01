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
        private bool Log { get; }

        public TestController(AppDb db, bool log = true)
        {
            Db = db;
            Log = log;
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
                if (Log)
                    await Logger.LoggerFactory.LogError(e);
                return null;
            }
            

            //create query
            var cmd = TestQuery.GetData(Db);

            //List to read all data
            List<Test> values = new List<Test>();

            //Create Reader
            MySqlDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
            }
            catch(Exception e)
            {
                if (Log)
                    await Logger.LoggerFactory.LogError(e);
                return null;
            }
            
            //Read data
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

            if (Log)
                await Logger.LoggerFactory.LogInformation(Db.Connection.Database.ToString() + " GET all values");

            return values;
        }

        // GET: api/Test/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<Test> Get(uint id)
        {
            //open connection
            try
            {
                await Db.Connection.OpenAsync();
            }
            catch (Exception e)
            {
                if (Log)
                    await Logger.LoggerFactory.LogError(e);
                return null;
            }

            //create query
            var cmd = TestQuery.GetData(id, Db);

            //Create Reader
            Test test;
            MySqlDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                if (Log)
                    await Logger.LoggerFactory.LogError(e);
                return null;
            }

            //Read data
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

            if (Log)
                await Logger.LoggerFactory.LogInformation(Db.Connection.Database.ToString() + " GET all value with the id " + id);

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
