using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model
{
    public class @event
    {
        int id { get; set; }
        int type_id { get; set; }
        int article_id { get; set; }
        DateTime published { get; set; }
    }
}
