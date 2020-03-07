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
    
    [ApiController]
    [EnableCors("AllowAll")]
    [Route("api/DubiousArticle")]
    public class DubiousArticleController : ControllerBase
    {
        private AppDb Db { get; }
        private bool Log { get; }

        public DubiousArticleController(AppDb db, bool log = true)
        {
            Db = db;
            Log = log;
        }

        // GET: api/DubiousArticle
        [HttpGet]
        public async Task<IEnumerable<dubious_article>> Get()
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
            var cmd = DubiousArticleQuery.GetData(Db);

            //List to read all data
            List<dubious_article> values = new List<dubious_article>();

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
                values.Add(dubious_article.Parse(val));
            }

            await reader.DisposeAsync();
            await reader.CloseAsync();

            if (Log)
                await Logger.LoggerFactory.LogInformation(Db.Connection.Database.ToString() + " GET all values");

            return values;
        }

        // GET: api/DubiousArticle/5
        [HttpGet("{id}")]
        public async Task<dubious_article> Get(int id)
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
            var cmd = DubiousArticleQuery.GetData(Db, id);

            //Create Reader
            dubious_article d_article;
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
                await Logger.LoggerFactory.LogInformation(Db.Connection.Database.ToString() + " COULDN'T GET all value with the id " + id);
                return null;
            }
                
            Object[] val = new Object[reader.FieldCount];
            reader.GetValues(val);

            d_article = dubious_article.Parse(val);

            await reader.DisposeAsync();
            await reader.CloseAsync();

            if (Log)
                await Logger.LoggerFactory.LogInformation(Db.Connection.Database.ToString() + " GET all value with the id " + id);

            return d_article;
        }

        /*// POST: api/DubiousArticle
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/DubiousArticle/5
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
