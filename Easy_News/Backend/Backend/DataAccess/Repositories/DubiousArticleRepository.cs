using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccess
{
    public class DubiousArticleRepository : Repository<EFModels.DubiousArticle, Dbo.Model.dubious_article>, Interfaces.IDubiousArticleRepository
    {
        public DubiousArticleRepository(EFModels.earlynews_testContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }
    }
}
