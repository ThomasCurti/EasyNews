using Backend.DataAccess;
using Backend.DataAccess.EFModels;
using Backend.Dbo;
using Backend.Dbo.Model;
using Backend.Logger;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text.Json;
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
        private ILogger _logger;
        private bool _log { get; }

        public DubiousArticleController(DubiousArticleRepository dubiousArticleRepository, ILogger logger, bool log = true)
        {
            _dubiousArticleRepository = dubiousArticleRepository;
            _dubiousArticleRepository.DoLog = log;
            _log = log;
            _logger = logger;
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
        [HttpPost]
        public async void Post([FromBody] JsonElement value)
        {
            Dbo.Model.dubious_article dubiousArticle = null;
            try
            {
                string val = System.Text.Json.JsonSerializer.Serialize(value);
                dubiousArticle = JsonConvert.DeserializeObject<dubious_article>(val);
            }
            catch (Exception e)
            {
                _logger.Error("Tried to insert dubious article but the value was wrong");
                _logger.Error(e.Message);
                return;
            }
            await _dubiousArticleRepository.InsertWithoutDuplicate(dubiousArticle);
        }

        //DELETE: api/DubiousArticle
        [HttpDelete]
        public async void DeleteAll()
        {
            await _dubiousArticleRepository.DeleteAll();
        }
    }
}
