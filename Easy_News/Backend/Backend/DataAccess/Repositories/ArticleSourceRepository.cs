using AutoMapper;

namespace Backend.DataAccess
{
    public class ArticleSourceRepository : Repository<EFModels.ArticleSource, Dbo.Model.article_source>, Interfaces.IArticleSourceRepository
    {
        public ArticleSourceRepository(EFModels.earlynews_testContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }
    }
}
