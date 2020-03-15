using AutoMapper;

namespace Backend.DataAccess
{
    public class EventRepository : Repository<EFModels.Event, Dbo.Model.Event>, Interfaces.IEventRepository
    {
        public EventRepository(EFModels.earlynews_testContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }
    }
}
