using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class EventType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public virtual IEnumerable<EachEventTypes> EachEventTypes { get; set; }
    }
}
