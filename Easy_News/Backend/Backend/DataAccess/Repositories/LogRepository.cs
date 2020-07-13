using AutoMapper;
using Serilog;

namespace Backend.DataAccess
{
    public class LogRepository : Repository<EFModels.Logs, Dbo.Model.log>, Interfaces.ILogRepository
    {
        public LogRepository(EFModels.earlynews_testContext ctx, IMapper mapper, ILogger ilogger) : base(ctx, mapper, null, ilogger)
        {
        }
    }
}
