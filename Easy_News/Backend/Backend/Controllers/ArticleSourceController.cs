using Backend.DataAccess;
using Backend.Dbo;
using Backend.Dbo.Model;
using Backend.Logger;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/ArticleSource")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class ArticleSourceController : ControllerBase
    {
        private readonly ArticleSourceRepository _articleSourceRepository;
        private bool _log { get; }

        public ArticleSourceController(ArticleSourceRepository articleSourceRepository, bool log = true)
        {
            _articleSourceRepository = articleSourceRepository;
            _log = log;
        }

        // GET: api/ArticleSource
        [HttpGet]
        public async Task<IEnumerable<article_source>> Get()
        {
            return await _articleSourceRepository.Get();
        }

        // GET: api/ArticleSource/5
        [HttpGet("{id}")]
        public async Task<article_source> Get(int id)
        {
            var val = _articleSourceRepository.Get(id).Result;

            try
            {
                List<Dbo.Model.article_source> list = new List<Dbo.Model.article_source>(val);
                return list[0];
            }
            catch (Exception e)
            {
                if (_log)
                    await LoggerFactory.LogError(e);
                return null;
            }
        }

        // POST: api/ArticleSource
        /*[HttpPost]
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
