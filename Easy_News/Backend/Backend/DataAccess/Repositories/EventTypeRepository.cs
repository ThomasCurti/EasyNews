using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccess
{
    public class EventTypeRepository : Repository<EFModels.EventType, Dbo.Model.event_type>, Interfaces.IEventTypeRepository
    {
        public EventTypeRepository(EFModels.earlynews_testContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }
    }
}
