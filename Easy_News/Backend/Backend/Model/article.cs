using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model
{
    public class article
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string full_article { get; set; }
        public int source_id { get; set; }

        public static article Parse(Object[] val)
        {
            return new article
            {
                id = Int32.Parse(val[0].ToString()),
                title = val[1].ToString(),
                description = val[2].ToString(),
                full_article = val[3].ToString(),
                source_id = Int32.Parse(val[4].ToString()),
            };
        }
    }
}
