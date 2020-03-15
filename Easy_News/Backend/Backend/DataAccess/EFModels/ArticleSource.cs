using System;
using System.Collections.Generic;

namespace Backend.DataAccess.EFModels
{
    public partial class ArticleSource
    {
        public ArticleSource()
        {
            Article = new HashSet<Article>();
            DubiousArticleOtherSource = new HashSet<DubiousArticle>();
            DubiousArticleSource = new HashSet<DubiousArticle>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Article> Article { get; set; }
        public virtual ICollection<DubiousArticle> DubiousArticleOtherSource { get; set; }
        public virtual ICollection<DubiousArticle> DubiousArticleSource { get; set; }
    }
}
