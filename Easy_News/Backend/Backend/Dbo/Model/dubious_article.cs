using System;
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
        public string fullArticleSource { get; set; }
        public string kwFrequency { get; set; }

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
                fullArticleSource = val[3].ToString(),
                kwFrequency = val[4].ToString()
            };
        }

    }
}
