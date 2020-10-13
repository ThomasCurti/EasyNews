using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dbo.Model
{
    public class log : IObjectWithId
    {
        public long id { get; set; }
        public string Type { get; set; }
        public string Class { get; set; }
        public string Message { get; set; }
    }
}
