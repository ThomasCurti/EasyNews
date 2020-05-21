using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.DataAccess;
using Backend.Dbo.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/Scenarios")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class ScenarioController : ControllerBase
    {
        private readonly ScenarioRepository _scenarioRepository;
        private LogRepository _logRepository;
        private bool _log { get; }

        public ScenarioController(ScenarioRepository scenarioRepository, bool log = true)
        {
            _scenarioRepository = scenarioRepository;
            _scenarioRepository.Log = log;
            _log = log;
        }

        // GET: api/Scenario
        [HttpGet]
        public async Task<IEnumerable<scenarios>> Get()
        {
            return await _scenarioRepository.Get();
        }

        // GET: api/Scenario/5
        [HttpGet("{id}")]
        public async Task<scenarios> Get(int id)
        {
            var val = _scenarioRepository.Get(id).Result;

            try
            {
                List<Dbo.Model.scenarios> list = new List<Dbo.Model.scenarios>(val);
                return list[0];
            }
            catch (Exception e)
            {
                if (_log)
                    await Logger.Logger.LogError(e, "EventTypeController", _logRepository);
                return null;
            }
        }


    }
}