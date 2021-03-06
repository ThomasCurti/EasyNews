﻿using AutoMapper;
using Serilog;

namespace Backend.DataAccess
{
    public class ArticleRepository : Repository<EFModels.Article, Dbo.Model.article>, Interfaces.IArticleRepository
    {
        public ArticleRepository(EFModels.earlynews_testContext ctx, IMapper mapper, LogRepository logger, ILogger ilogger) : base(ctx, mapper, logger, ilogger)
        {
        }
    }
}
