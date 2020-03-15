using System;
using System.Collections.Generic;

namespace Backend.DataAccess.EFModels
{
    public partial class Event
    {
        public int Id { get; set; }
        public int? TypeId { get; set; }
        public int? ArticleId { get; set; }
        public DateTime? Published { get; set; }

        public virtual Article Article { get; set; }
        public virtual EventType Type { get; set; }
    }
}
