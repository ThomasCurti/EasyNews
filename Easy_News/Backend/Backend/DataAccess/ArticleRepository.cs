using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DataAccess
{
    public class ArticleRepository : Repository<EFModels.Article, Dbo.Model.article>, Interfaces.IArticleRepository
    {
        public ArticleRepository(EFModels.earlynews_testContext ctx, IMapper mapper) : base(ctx, mapper)
        {
        }
    }
}
