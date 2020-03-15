using System;
using System.Collections.Generic;

namespace Backend.models
{
    public partial class Article
    {
        public Article()
        {
            Event = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FullArticle { get; set; }
        public int? SourceId { get; set; }

        public virtual ArticleSource Source { get; set; }
        public virtual ICollection<Event> Event { get; set; }
    }
}
