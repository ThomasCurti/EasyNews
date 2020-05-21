using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dbo.Model
{
    public class scenarios : IObjectWithId
    {
        public long id { get; set; }
        public string Virus { get; set; }
        public int TownId { get; set; }
        public string BeginDate { get; set; }
        public string Description { get; set; }
    }
}
