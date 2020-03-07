using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model
{
    public class article
    {
        int id { get; set; }
        string title { get; set; }
        string description { get; set; }
        string full_article { get; set; }
        int source_id { get; set; }
    }
}
