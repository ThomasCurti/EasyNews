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
        private LogRepository _logRepository;
        private bool _log;

        public ArticleController(ArticleRepository articleRepository, bool log = true)
        {
            _articleRepository = articleRepository;
            _articleRepository.DoLog = log;
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
                    await Logger.Logger.LogError(e, "ArticleController", _logRepository);
                Console.WriteLine(e.ToString());
                return null;
            }

        }
    }
}
