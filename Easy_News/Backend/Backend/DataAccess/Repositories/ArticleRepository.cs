using AutoMapper;

namespace Backend.DataAccess
{
    public class ArticleRepository : Repository<EFModels.Article, Dbo.Model.article>, Interfaces.IArticleRepository
    {
        public ArticleRepository(EFModels.earlynews_testContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }
    }
}
