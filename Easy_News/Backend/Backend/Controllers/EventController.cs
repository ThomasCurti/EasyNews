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
    [Route("api/Event")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class EventController : ControllerBase
    {
        private readonly EventRepository _eventRepository;
        private bool _log { get; }

        public EventController(EventRepository eventRepository, bool log = true)
        {
            _eventRepository = eventRepository;
            _eventRepository.Log = log;
            _log = log;
        }

        // GET: api/Event
        [HttpGet]
        public async Task<IEnumerable<Event>> Get()
        {
            return await _eventRepository.Get();
        }

        // GET: api/Event/5
        [HttpGet("{id}")]
        public async Task<Event> Get(int id)
        {
            var val = _eventRepository.Get(id).Result;

            try
            {
                List<Dbo.Model.Event> list = new List<Dbo.Model.Event>(val);
                return list[0];
            }
            catch (Exception e)
            {
                if (_log)
                    await Logger.Logger.LogError(e, "EventController");
                return null;
            }
        }

        // POST: api/Event
        /*[HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Event/5
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
