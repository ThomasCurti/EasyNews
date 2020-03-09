using System;

namespace Backend.Model
{
    public class Event
    {
        public int id { get; set; }
        public int type_id { get; set; }
        public int article_id { get; set; }
        public DateTime published { get; set; }

        public static Event Parse(Object[] val)
        {
            return new Event
            {
                id = Int32.Parse(val[0].ToString()),
                type_id = Int32.Parse(val[1].ToString()),
                article_id = Int32.Parse(val[2].ToString()),
                published = DateTime.Parse(val[3].ToString()),
            };
        }

    }   
}
