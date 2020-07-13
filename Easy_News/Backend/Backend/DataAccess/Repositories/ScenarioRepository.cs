using AutoMapper;
using Serilog;

namespace Backend.DataAccess
{
    public class ScenarioRepository : Repository<EFModels.Scenarios, Dbo.Model.scenarios>, Interfaces.IScenarioRepository
    {
        public ScenarioRepository(EFModels.earlynews_testContext ctx, IMapper mapper, LogRepository logger, ILogger ilogger) : base(ctx, mapper, logger, ilogger)
        {
        }
    }
}
