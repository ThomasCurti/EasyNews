﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dbo.Model
{
    public class dubious_article : IObjectWithId
    {
        public long id { get; set; }
        public string title { get; set; }
        public int? sourceId { get; set; }
        public string full_article_source { get; set; }
        public int? otherSourceId { get; set; }
        public string? full_article_other { get; set; }
        public bool seen_twice { get; set; }

        public static dubious_article Parse(Object[] val)
        {
            int? other;
            if (val[4] == null)
                other = null;
            else
                other = Int32.Parse(val[4].ToString());

            string? full;
            if (val[5] == null)
                full = null;
            else
                full = val[5].ToString();

            return new dubious_article
            {
                id = Int32.Parse(val[0].ToString()),
                title = val[1].ToString(),
                sourceId = Int32.Parse(val[2].ToString()),
                full_article_source = val[3].ToString(),
                otherSourceId = other,
                full_article_other = full,
                seen_twice = Boolean.Parse(val[6].ToString()),
            };
        }

    }
}
