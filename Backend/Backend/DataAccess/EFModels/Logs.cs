using System;
using System.Collections.Generic;

namespace Backend.DataAccess.EFModels
{
    public partial class Logs
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Class { get; set; }
        public string Message { get; set; }
    }
}
