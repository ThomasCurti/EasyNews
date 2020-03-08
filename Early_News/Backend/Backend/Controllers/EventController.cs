using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.DataAccess;
using Backend.Dbo;
using Backend.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace Backend.Controllers
{
    [Route("api/Event")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class EventController : ControllerBase
    {
        private AppDb Db { get; }
        private bool Log { get; }

        public EventController(AppDb db, bool log = true)
        {
            Db = db;
            Log = log;
        }

        // GET: api/Event
        [HttpGet]
        public async Task<IEnumerable<Event>> Get()
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
            var cmd = EventQuery.GetData(Db);

            //List to read all data
            List<Event> values = new List<Event>();

            //Create Reader
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
            while (reader.Read())
            {
                Object[] val = new Object[reader.FieldCount];
                reader.GetValues(val);
                values.Add(Event.Parse(val));
            }

            await reader.DisposeAsync();
            await reader.CloseAsync();

            if (Log)
                await Logger.LoggerFactory.LogInformation(Db.Connection.Database.ToString() + " GET all values");

            return values;
        }

        // GET: api/Event/5
        [HttpGet("{id}")]
        public async Task<Event> Get(int id)
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
            var cmd = EventQuery.GetData(Db, id);

            //Create Reader
            Event ev;
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
            if (!reader.Read())
            {
                if(Log)
                    await Logger.LoggerFactory.LogInformation(Db.Connection.Database.ToString() + " COULDN'T GET all value with the id " + id);
                return null;
            }

            Object[] val = new Object[reader.FieldCount];
            reader.GetValues(val);

            ev = Event.Parse(val);

            await reader.DisposeAsync();
            await reader.CloseAsync();

            if (Log)
                await Logger.LoggerFactory.LogInformation(Db.Connection.Database.ToString() + " GET all value with the id " + id);

            return ev;
        }

        /*// POST: api/Event
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Event/5
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
