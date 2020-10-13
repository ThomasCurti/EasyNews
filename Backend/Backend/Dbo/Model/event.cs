using System;

namespace Backend.Dbo.Model
{
    public class Event : IObjectWithId
    {
        public long id { get; set; }
        public int? TypeId { get; set; }
        public int? ArticleId { get; set; }
        public DateTime? published { get; set; }

        public static Event Parse(Object[] val)
        {
            return new Event
            {
                id = Int32.Parse(val[0].ToString()),
                TypeId = Int32.Parse(val[1].ToString()),
                ArticleId = Int32.Parse(val[2].ToString()),
                published = DateTime.Parse(val[3].ToString()),
            };
        }

    }   
}
