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
    [Route("api/Article")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class ArticleController : ControllerBase
    {
        private AppDb Db { get; }
        private bool Log { get; }

        public ArticleController(AppDb db, bool log = true)
        {
            Db = db;
            Log = log;
        }

        // GET: api/Article
        [HttpGet]
        public async Task<IEnumerable<article>> Get()
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
            var cmd = ArticleQuery.GetData(Db);

            //List to read all data
            List<article> values = new List<article>();

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
                values.Add(article.Parse(val));
            }

            await reader.DisposeAsync();
            await reader.CloseAsync();

            if (Log)
                await Logger.LoggerFactory.LogInformation(Db.Connection.Database.ToString() + " GET all values");

            return values;
        }

        // GET: api/Article/5
        [HttpGet("{id}")]
        public async Task<article> Get(long id)
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
            var cmd = ArticleQuery.GetData(Db, id);

            //Create Reader
            article art;
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
                if (Log)
                    await Logger.LoggerFactory.LogInformation(Db.Connection.Database.ToString() + " COULDN'T GET all value with the id " + id);
                return null;
            }

            Object[] val = new Object[reader.FieldCount];
            reader.GetValues(val);

            art = article.Parse(val);

            await reader.DisposeAsync();
            await reader.CloseAsync();

            if (Log)
                await Logger.LoggerFactory.LogInformation(Db.Connection.Database.ToString() + " GET all value with the id " + id);

            return art;
        }

        /*// POST: api/Article
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Article/5
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
