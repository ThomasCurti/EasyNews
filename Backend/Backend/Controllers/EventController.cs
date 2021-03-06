﻿using Backend.DataAccess;
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
        private LogRepository _logRepository;
        private bool _log { get; }

        public EventController(EventRepository eventRepository, bool log = true)
        {
            _eventRepository = eventRepository;
            _eventRepository.DoLog = log;
            _log = log;
        }

        // GET: api/Event
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _eventRepository.Get());
        }

        // GET: api/Event/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var val = _eventRepository.Get(id).Result;

            try
            {
                List<Dbo.Model.Event> list = new List<Dbo.Model.Event>(val);
                if (list[0] == null)
                    return NotFound();
                return Ok(list[0]);
            }
            catch (Exception e)
            {
                if (_log)
                    await Logger.Logger.LogError(e, "EventController", _logRepository);
                return NotFound();
            }
        }
    }
}
