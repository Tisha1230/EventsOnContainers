using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class EachEvent
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        //public string State {get; set;}

        public int AvailableSeats { get; set; }

        public int Likes { get; set; }
        //public string AgeGroup {get; set;}


        public int TypeId { get; set; }
        public int LocationId { get; set; }

        public string TicketType { get; set; }//free/paid/subscription/trial


       // public virtual EventType EventType { get; set; }

        //public virtual IEnumerable<EventType> EventType { get; set; }

        public virtual EventLocation EventLocation { get; set; }

        public virtual IEnumerable<EachEventTypes> EachEventTypes { get; set; }



    }
}
