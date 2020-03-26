using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccess
{
    public class EventRepository : Repository<EFModels.Event, Dbo.Model.Event>, Interfaces.IEventRepository
    {
        public EventRepository(EFModels.earlynews_testContext ctx, IMapper mapper, LogRepository logger) : base(ctx, mapper, logger)
        {
        }
    }
}
