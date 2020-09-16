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
    [Route("api/EventType")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class EventTypeController : ControllerBase
    {
        private readonly EventTypeRepository _eventTypeRepository;
        private LogRepository _logRepository;
        private bool _log { get; }

        public EventTypeController(EventTypeRepository eventTypeRepository, bool log = true)
        {
            _eventTypeRepository = eventTypeRepository;
            _eventTypeRepository.DoLog = log;
            _log = log;
        }

        // GET: api/EventType
        [HttpGet]
        public async Task<IEnumerable<event_type>> Get()
        {
            return await _eventTypeRepository.Get();
        }

        // GET: api/EventType/5
        [HttpGet("{id}")]
        public async Task<event_type> Get(int id)
        {
            var val = _eventTypeRepository.Get(id).Result;

            try
            {
                List<Dbo.Model.event_type> list = new List<Dbo.Model.event_type>(val);
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
