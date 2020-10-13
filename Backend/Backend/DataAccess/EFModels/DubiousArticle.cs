using System;
using System.Collections.Generic;

namespace Backend.DataAccess.EFModels
{
    public partial class DubiousArticle
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? SourceId { get; set; }
        public string FullArticleSource { get; set; }
        public string KwFrequency { get; set; }

        public virtual ArticleSource Source { get; set; }
    }
}
