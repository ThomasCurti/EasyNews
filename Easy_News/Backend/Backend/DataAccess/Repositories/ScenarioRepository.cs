using AutoMapper;

namespace Backend.DataAccess
{
    public class ScenarioRepository : Repository<EFModels.Scenarios, Dbo.Model.scenarios>, Interfaces.IScenarioRepository
    {
        public ScenarioRepository(EFModels.earlynews_testContext ctx, IMapper mapper, LogRepository logger) : base(ctx, mapper, logger)
        {
        }
    }
}
