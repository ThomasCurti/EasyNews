using AutoMapper;

namespace Backend.DataAccess
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<DataAccess.EFModels.Article, Dbo.Model.article>();
            CreateMap<Dbo.Model.article, DataAccess.EFModels.Article>();

            CreateMap<DataAccess.EFModels.ArticleSource, Dbo.Model.article_source>();
            CreateMap<Dbo.Model.article_source, DataAccess.EFModels.ArticleSource>();

            CreateMap<DataAccess.EFModels.DubiousArticle, Dbo.Model.dubious_article>();
            CreateMap<Dbo.Model.dubious_article, DataAccess.EFModels.DubiousArticle>();

            CreateMap<DataAccess.EFModels.Event, Dbo.Model.Event>();
            CreateMap<Dbo.Model.Event, DataAccess.EFModels.Event>();

            CreateMap<DataAccess.EFModels.EventType, Dbo.Model.event_type>();
            CreateMap<Dbo.Model.event_type, DataAccess.EFModels.EventType>();

            CreateMap<DataAccess.EFModels.Logs, Dbo.Model.log>();
            CreateMap<Dbo.Model.log, DataAccess.EFModels.Logs>();

            CreateMap<DataAccess.EFModels.Scenarios, Dbo.Model.scenarios>();
            CreateMap<Dbo.Model.scenarios, DataAccess.EFModels.Scenarios>();
        }
    }
}
