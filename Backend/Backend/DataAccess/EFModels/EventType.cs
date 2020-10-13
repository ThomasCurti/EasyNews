using System;
using System.Collections.Generic;

namespace Backend.DataAccess.EFModels
{
    public partial class EventType
    {
        public EventType()
        {
            Event = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Event> Event { get; set; }
    }
}
