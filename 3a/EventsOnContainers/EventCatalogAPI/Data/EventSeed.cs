using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public static class EventSeed
    {
        public static void Seed(EventContext eventContext)
        {
            eventContext.Database.Migrate();
            
            if(!eventContext.EventLocations.Any()) //if no record then insert some sample data
            {
                eventContext.EventLocations.AddRange(GetEventLocations());
                //executing the method GetEventLocation whose goal is to return an array of eventLocations(sample records) which we will get inserted into database
                //need to do SaveChanges, since this method is doing a bulk insert. if not done save then all the insert statements changes in this method will be temporary and will not write in database

                eventContext.SaveChanges();
            }

            if (!eventContext.EventTypes.Any())
            {
                eventContext.EventTypes.AddRange(GetEventTypes());
                eventContext.SaveChanges();
            }

            if(!eventContext.Events.Any())
            {
                eventContext.Events.AddRange(GetEvents());
                eventContext.SaveChanges();
            }

            

            if (!eventContext.eachEventTypes.Any())
            {
                eventContext.eachEventTypes.AddRange(GetEachEventTypes(eventContext));
                eventContext.SaveChanges();
            }



        }

        private static IEnumerable<EachEvent> GetEvents()
        {
            return new List<EachEvent>()
            {

                new EachEvent { TypeId = 4,LocationId = 1, Description = "Try it, taste it, adopt it", EventName = "Be A Vegan:Beginner", Price = 0.00M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1", Address="Araya's vegan cafe hut", Likes=10, Date=new DateTime(2021, 09, 09, 10, 10, 00 ), ZipCode="98034", TicketType="Free" ,AvailableSeats=100},
                new EachEvent { TypeId = 1, LocationId = 2, Description = "Get high at Trinity Nightclub", EventName = "SunTan Disco", Price = 35.99M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2", Address="Rose hill hall,124th ave, Kirkland",Likes=2,  Date=new DateTime(2021, 09, 11, 21, 00, 00 ) ,ZipCode="98055" ,TicketType="Paid",AvailableSeats=100 },
                new EachEvent { TypeId = 3, LocationId = 3, Description = "You have already won gold medal", EventName = "Pinkathon", Price = 10.50M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3", Address="Bellevue stadium",Likes=0,  Date=new DateTime(2021, 09, 05, 10, 30, 00 ), ZipCode="98009",TicketType="Paid",AvailableSeats=500},
                new EachEvent { TypeId = 3,LocationId = 2, Description = "Dine for a cause", EventName = "Foundation Hitech Fundraiser", Price = 12.00M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4", Address="Boys and girls club,84th street", Date=new DateTime(2021, 09, 06, 10, 10, 00 ), ZipCode="98055" ,TicketType="Paid",AvailableSeats=75},
                new EachEvent { TypeId = 2, LocationId = 2, Description = "Wine, Yoga and Fun", EventName = "Heritage Brunch", Price = 40.00M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5" , Address="Novotel, Kirkland",Likes=7,  Date=new DateTime(2021, 09, 22, 12, 30, 00 ), ZipCode="98055", TicketType="Paid",AvailableSeats=40},
                new EachEvent { TypeId = 7, LocationId = 1, Description = "Get placed at your dream job", EventName = "Primier Virtual Tech", Price = 50.00M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/6", Address="Remote" ,Likes =2,  Date=new DateTime(2021, 08, 22, 11, 30, 00 ), ZipCode="98033", TicketType="Trial",AvailableSeats=500},
                new EachEvent { TypeId = 2, LocationId = 2, Description = "Saturday brunch with friends and family!", EventName = "Eat All You Can", Price = 50.00M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7" , Address="Sea high, golf street 11th ave", Likes=3,  Date=new DateTime(2021, 09, 09, 13, 00, 00 ), ZipCode="99054" ,TicketType="Paid",AvailableSeats=70},
                new EachEvent { TypeId = 4, LocationId = 4, Description = "Powerpacked Yoga, meditation and Zumba", EventName = "Summer Fitness Expo", Price = 15.99M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8", Address="Online",  Likes=9,  Date=new DateTime(2021, 08, 25, 11, 00, 00 ) , TicketType="Subsscription",AvailableSeats=100},
                new EachEvent { TypeId = 5, LocationId = 1, Description = "Get caught, get lost in the workd of Shakespeare", EventName = "Shakespeare", Price = 10.00M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/9", Address="Great Lake stadium", Likes=8, Date=new DateTime(2021, 09, 13, 20, 15, 00 ) , ZipCode="98033", TicketType="Paid",AvailableSeats=150},
                new EachEvent { TypeId = 2, LocationId = 3, Description = "Achieve your culinary dreams", EventName = "Bakethon2.0", Price = 12.50M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/10" , Address="Sasha's palace kitchen", Likes=1,  Date=new DateTime(2021, 09, 09, 17, 00, 00 ) ,ZipCode="98810", TicketType="Trial",AvailableSeats=25},
                new EachEvent { TypeId = 6, LocationId = 3, Description = "Be an all rounder, get hired at the best!", EventName = "Hitech Job Expo", Price = 25.00M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/11" , Address="Sea hawks stadium", Likes=0,  Date=new DateTime(2021, 08, 10, 10, 10, 00 ) ,ZipCode="98810" ,TicketType="Subscription", AvailableSeats=300},
                new EachEvent { TypeId = 7, LocationId = 2, Description = "A pricesless vegan experience", EventName = "CookVegan", Price = 20.00M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/12", Address="Remote",  Likes=3,Date=new DateTime(2021, 08, 25, 09, 30, 00 ), ZipCode="98056",TicketType="Paid",AvailableSeats=100 },
                new EachEvent { TypeId = 5, LocationId = 3, Description = "The most loved and breathtaking play of the year", EventName = "Elequent", Price = 30.00M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/13" , Address="Grandeur indoor Park", Likes=5,  Date=new DateTime(2021, 09, 30, 19, 00, 00 ), ZipCode="98009", TicketType="Paid", AvailableSeats=150},
                new EachEvent { TypeId = 1, LocationId = 2, Description = "Massive Fridays with DJ Samuel", EventName = "Summer Star Electric", Price = 70.99M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/14", Address="Q Nighclub", Likes=11,  Date=new DateTime(2021, 08, 30, 21, 30, 00 ),ZipCode="98029", TicketType="Paid" , AvailableSeats=80},
                new EachEvent { TypeId = 3, LocationId = 1, Description = "Come.. take part, start the change", EventName = "Peace Youth Peloton", Price = 0.00M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/15", Address="Redmond high school, 46th Ave",Likes=9,  Date=new DateTime(2021, 09, 14, 07, 30, 00 ), ZipCode="98034", TicketType="Free" , AvailableSeats=500},
                new EachEvent { TypeId = 4, LocationId = 3, Description = "Join for a fun vinyasa yoga flow to music while enjoying the sunshine and the lake view", EventName = "Vinyasa Yoga in the Park", Price = 20.00M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/16" , Address="Bellevue downtown park", Likes=0,  Date=new DateTime(2021, 08, 10, 10, 10, 00 ) , ZipCode="98009" ,TicketType="Subscription", AvailableSeats=50},
                new EachEvent { TypeId = 1, LocationId = 1, Description = "An open-format DJ specializing in mixing pop, country, hip-hop and rock", EventName ="On the rock music" , Price = 79.99M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/17", Address="Queer Bar, 11th ave",  Likes=1,Date=new DateTime(2021, 08, 25, 09, 30, 00 ), ZipCode="98033",TicketType="Paid",AvailableSeats=200 },
                new EachEvent { TypeId = 4, LocationId = 1, Description = "Hike through meadows, along mountain streams, and over rocky passes.", EventName = "Summer teen hike", Price = 25.00M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/18" , Address="Redmond ridge trails", Likes=5,  Date=new DateTime(2021, 09, 30, 19, 00, 00 ),ZipCode="98033", TicketType="Paid", AvailableSeats=25 },
                new EachEvent { TypeId = 1, LocationId = 2, Description = "Indie/Acoustic/Folk act from Cleveland, Ohio", EventName = "DJ Tony", Price = 89.99M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/19", Address="Green club, Kirkland", Likes=10,  Date=new DateTime(2021, 08, 30, 21, 30, 00 ), ZipCode="98056", TicketType="Paid", AvailableSeats=100 },
                new EachEvent { TypeId = 6, LocationId = 4, Description = "Business conference that helps you become a stronger leader", EventName = "Seattle yearly career seminar", Price = 0.00M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/20", Address="Online",Likes=9,  Date=new DateTime(2021, 09, 14, 07, 30, 00 ), TicketType="Free" ,AvailableSeats=150},
            };
        }

        private static IEnumerable<EventType> GetEventTypes()
        {
            return new List<EventType>
            {
                new EventType
                {
                    Type = "Music"
                },
                 new EventType
                {
                    Type = "Food & Drink"
                },
                new EventType
                {
                    Type="Charity & Causes"
                },
                new EventType
                {
                    Type="Health & Fitness"
                },
                new EventType
                {
                    Type="Movies & Plays"
                },
                 new EventType
                {
                    Type="Career Fairs"
                }

            };
        }

        private static IEnumerable<EventLocation> GetEventLocations()
        {
            return new List<EventLocation>
           {
                new EventLocation
                {
                    City = "Redmond"
                },
                new EventLocation
                {
                    City = "Kirkland"
                },
                new EventLocation
                {
                    City="Bellevue"
                },
                new EventLocation
                {
                    City ="Online"
                }
            };
            //   new EventLocation
            //    {
            //        City = "Renton"
            //    },
            //    new EventLocation
            //    {
            //        City = "Seattle"
            //    },
            //     new EventLocation
            //     {
            //         City = "Bothell"
            //     },
            //    new EventLocation
            //    {
            //        City = "Kenmore"
            //    },
            //       new EventLocation
            //       {
            //           City = "Sammamish"
            //       },
            //        new EventLocation
            //        {
            //            City = "Issaquah"
            //        },
            //          new EventLocation
            //          {
            //              City = "Woodinville"
            //          }
            //    };

        }

        private static IEnumerable<EachEventTypes> GetEachEventTypes(EventContext context)
        {
            return new List<EachEventTypes>
            {
                new EachEventTypes { EventId = 1, TypeId = 4 },
                new EachEventTypes { EventId = 2, TypeId = 1 },
                new EachEventTypes { EventId = 3, TypeId = 3 },
                new EachEventTypes { EventId = 5, TypeId = 2 },
                new EachEventTypes { EventId = 5, TypeId = 4 },
                new EachEventTypes { EventId = 6, TypeId = 6 },
                new EachEventTypes { EventId = 7, TypeId = 2 },
                new EachEventTypes { EventId = 8, TypeId = 4 },
                new EachEventTypes { EventId = 9, TypeId = 5 },
                new EachEventTypes { EventId = 10, TypeId = 2 },
                new EachEventTypes { EventId = 11, TypeId = 6 },
                new EachEventTypes { EventId = 12, TypeId = 2 },
                new EachEventTypes { EventId = 13, TypeId = 5 },
                new EachEventTypes { EventId = 14, TypeId = 1 },
                new EachEventTypes { EventId = 15, TypeId = 3 },
                new EachEventTypes { EventId = 16, TypeId = 4 },
                new EachEventTypes { EventId = 17, TypeId = 1 },
                new EachEventTypes { EventId = 18, TypeId = 4 },
                new EachEventTypes { EventId = 19, TypeId = 1 },
                new EachEventTypes { EventId = 20, TypeId = 6 }
               };

        }

       
    
    }
}
