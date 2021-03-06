﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Backend.DataAccess
{
    public class ArticleSourceRepository : Repository<EFModels.ArticleSource, Dbo.Model.article_source>, Interfaces.IArticleSourceRepository
    {
        public ArticleSourceRepository(EFModels.earlynews_testContext ctx, IMapper mapper, LogRepository logger, ILogger ilogger) : base(ctx, mapper, logger, ilogger)
        {
        }
    }
}
