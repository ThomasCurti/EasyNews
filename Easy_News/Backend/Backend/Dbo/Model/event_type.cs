using System;

namespace Backend.Dbo.Model
{
    public class event_type
    {
        public int id { get; set; }
        public string name { get; set; }

        public static event_type Parse(Object[] val)
        {
            return new event_type
            {
                id = Int32.Parse(val[0].ToString()),
                name = val[1].ToString(),
            };
        }
    }
}
