using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.DataAccess;
using Backend.Logger;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/Article")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class ArticleController : ControllerBase
    {
        private readonly ArticleRepository _articleRepository;
        private bool _log;

        public ArticleController(ArticleRepository articleRepository, bool log = true)
        {
            _articleRepository = articleRepository;
            _articleRepository.Log = log;
            _log = log;
        }

        // GET: api/Article
        [HttpGet]
        public async Task<IEnumerable<Dbo.Model.article>> Get()
        {
            return await _articleRepository.Get();
        }

        // GET: api/Article/5
        [HttpGet("{id}")]
        public async Task<Dbo.Model.article> Get(int id)
        {
            var val = _articleRepository.Get(id).Result;

            try
            {
                List<Dbo.Model.article> list = new List<Dbo.Model.article>(val);
                return list[0];
            }
            catch (Exception e)
            {
                if (_log)
                    await LoggerFactory.LogError(e);
                return null;
            }
            
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
