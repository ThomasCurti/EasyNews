using Backend.Dbo;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/ArticleSource")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class ArticleSourceController : ControllerBase
    {
        private AppDb Db { get; }
        private bool Log { get; }

        public ArticleSourceController(AppDb db, bool log = true)
        {
            Db = db;
            Log = log;
        }

        /*// GET: api/ArticleSource
        [HttpGet]
        public async Task<IEnumerable<article_source>> Get()
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
            var cmd = ArticleSourceQuery.GetData(Db);

            //List to read all data
            List<article_source> values = new List<article_source>();

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
                values.Add(article_source.Parse(val));
            }

            await reader.DisposeAsync();
            await reader.CloseAsync();

            if (Log)
                await Logger.LoggerFactory.LogInformation(Db.Connection.Database.ToString() + " GET all values");

            return values;
        }

        // GET: api/ArticleSource/5
        [HttpGet("{id}")]
        public async Task<article_source> Get(int id)
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
            var cmd = ArticleSourceQuery.GetData(Db, id);

            //Create Reader
            article_source art;
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

            art = article_source.Parse(val);

            await reader.DisposeAsync();
            await reader.CloseAsync();

            if (Log)
                await Logger.LoggerFactory.LogInformation(Db.Connection.Database.ToString() + " GET all value with the id " + id);

            return art;
        }

        // POST: api/ArticleSource
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ArticleSource/5
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
