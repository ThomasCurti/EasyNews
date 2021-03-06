﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Backend.DataAccess
{
    public class EventTypeRepository : Repository<EFModels.EventType, Dbo.Model.event_type>, Interfaces.IEventTypeRepository
    {
        public EventTypeRepository(EFModels.earlynews_testContext ctx, IMapper mapper, LogRepository logger, ILogger ilogger) : base(ctx, mapper, logger, ilogger)
        {
        }
    }
}
