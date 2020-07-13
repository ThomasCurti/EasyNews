using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Backend.DataAccess
{
    public class EventRepository : Repository<EFModels.Event, Dbo.Model.Event>, Interfaces.IEventRepository
    {
        public EventRepository(EFModels.earlynews_testContext ctx, IMapper mapper, LogRepository logger, ILogger ilogger) : base(ctx, mapper, logger, ilogger)
        {
        }
    }
}
