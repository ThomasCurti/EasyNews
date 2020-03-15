using System;
using System.Collections.Generic;

namespace Backend.models
{
    public partial class DubiousArticle
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? SourceId { get; set; }
        public string FullArticleSource { get; set; }
        public int? OtherSourceId { get; set; }
        public string FullArticleOther { get; set; }
        public bool? SeenTwice { get; set; }

        public virtual ArticleSource OtherSource { get; set; }
        public virtual ArticleSource Source { get; set; }
    }
}
