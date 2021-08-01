using EventCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    public class EventContext: DbContext   //EventContext is the class that requires the location of database which is being passed through the constructor
    {
        //  context = database ; set = table
        //Dependency injection: if you see a parameter being passed in a constructor

        public EventContext(DbContextOptions options) : base(options) //injecting (To part )the location WHERE the database could be found in the connection string options which will pass it to base class(options)
        {

        }

        //telling WHICH tables should be created
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventLocation> EventLocations { get; set; }
        public DbSet<EachEvent> Events { get; set; }
        public DbSet<EachEventTypes> eachEventTypes { get; set; }

        //domain = model = entity = table
        //telling modelBuilder HOW the tables should be created
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventType>
                (e =>   //providing instructions for building table
                    {
                        e.Property(t => t.Id)
                            .IsRequired()
                            .ValueGeneratedOnAdd();

                        e.Property(t => t.Type)
                            .IsRequired()
                            .HasMaxLength(100);
                    }
                );

            modelBuilder.Entity<EventLocation>
                (e =>
                    {
                        e.Property(l => l.Id)
                            .IsRequired()
                            .ValueGeneratedOnAdd();

                        e.Property(l => l.City)
                            .IsRequired()
                            .HasMaxLength(100);
                    }
                );

            modelBuilder.Entity<EachEventTypes>()
                .HasKey(et => new { et.EventId, et.TypeId });
            //modelBuilder.Entity<EachEventTypes>()
            //    .HasOne(et => et.Event)
            //    .WithMany(v => v.EachEventTypes)
            //    .HasForeignKey(et => et.EventId);
            //modelBuilder.Entity<EachEventTypes>()
            //    .HasOne(et => et.eventType)
            //    .WithMany(t => t.EachEventTypes)
            //    .HasForeignKey(et => et.TypeId);



            modelBuilder.Entity<EachEvent>
                (e =>
                    {
                        e.Property(i => i.Id)
                         .IsRequired()
                         .ValueGeneratedOnAdd();

                        e.Property(i => i.EventName)
                         .IsRequired()
                         .HasMaxLength(100);

                        e.Property(i => i.Price)
                         .IsRequired()
                         .HasColumnType("decimal(5,2)");

                        e.Property(i => i.Date)
                         .IsRequired();

                        //e.HasOne(i => i.EventType)
                        // .WithMany()
                        // .HasForeignKey(i => i.TypeId);

                        e.HasOne(i => i.EventLocation)
                         .WithMany()
                         .HasForeignKey(i => i.LocationId);

                        e.Property(i => i.Address)
                         .IsRequired();

                        e.Property(i => i.AvailableSeats)
                         .IsRequired()
                         .HasColumnType("int");

                    }
                );

        }

    }
}
