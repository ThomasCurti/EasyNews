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

    [ApiController]
    [EnableCors("AllowAll")]
    [Route("api/DubiousArticle")]
    public class DubiousArticleController : ControllerBase
    {
        private readonly DubiousArticleRepository _dubiousArticleRepository;
        private LogRepository _logRepository;
        private bool _log { get; }

        public DubiousArticleController(DubiousArticleRepository dubiousArticleRepository, bool log = true)
        {
            _dubiousArticleRepository = dubiousArticleRepository;
            _dubiousArticleRepository.Log = log;
            _log = log;
        }

        // GET: api/DubiousArticle
        [HttpGet]
        public async Task<IEnumerable<dubious_article>> Get()
        {
            return await _dubiousArticleRepository.Get();
        }

        // GET: api/DubiousArticle/5
        [HttpGet("{id}")]
        public async Task<dubious_article> Get(int id)
        {
            var val = _dubiousArticleRepository.Get(id).Result;

            try
            {
                List<Dbo.Model.dubious_article> list = new List<Dbo.Model.dubious_article>(val);
                return list[0];
            }
            catch (Exception e)
            {
                if (_log)
                    await Logger.Logger.LogError(e, "DubiousArticleController", _logRepository);
                return null;
            }
        }

        // POST: api/DubiousArticle
        /*[HttpPost]
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
