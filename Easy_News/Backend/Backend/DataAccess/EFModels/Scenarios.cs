using System;
using System.Collections.Generic;

namespace Backend.DataAccess.EFModels
{
    public partial class Scenarios
    {
        public int Id { get; set; }
        public int IllnesType { get; set; }
        public string Virus { get; set; }
        public int TownId { get; set; }
        public string BeginDate { get; set; }
        public string Description { get; set; }
    }
}
