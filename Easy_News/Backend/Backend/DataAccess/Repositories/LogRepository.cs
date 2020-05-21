using AutoMapper;

namespace Backend.DataAccess
{
    public class LogRepository : Repository<EFModels.Logs, Dbo.Model.log>, Interfaces.ILogRepository
    {
        public LogRepository(EFModels.earlynews_testContext ctx, IMapper mapper) : base(ctx, mapper, null)
        {
        }
    }
}
