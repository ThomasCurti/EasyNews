using System;

namespace Backend.Model
{
    public class article_source
    {
        public int id { get; set; }
        public string name { get; set; }

        public static article_source Parse(Object[] val)
        {
            return new article_source
            {
                id = Int32.Parse(val[0].ToString()),
                name = val[1].ToString(),
            };
        }
    }
}
