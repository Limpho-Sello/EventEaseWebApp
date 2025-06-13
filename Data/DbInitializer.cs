using EventEaseWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EventEaseWebApp.Data
{ 
   public static class DbInitializer
        {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();
            context.Database.Migrate();
            if (context.Venues.Any() || context.Events.Any() || context.Bookings.Any()) return;


            var eventTypes = new List<EventType>
            {
                    new EventType { Name = "Conference" },
                    new EventType { Name = "Workshop" },
                    new EventType { Name = "Seminar" },
                    new EventType { Name = "Wedding" },
                    new EventType { Name = "Concert" }
            };
            context.EventTypes.AddRange(eventTypes);
            context.SaveChanges();


            // Seed Venues
            var venues = new List<Venue>
            {

                        new Venue
                        {

                            VenueName = "Church Auditorium",
                            Location = "023 Church Street",
                            Capacity = 300,
                            IsAvailable = false,
                            ImageUrl = "https://st10490959.blob.core.windows.net/venueimages/venue1.webp"
                        },
                        new Venue
                        {

                            VenueName = "Backyard View",
                            Location = "985 Riverside Road",
                            Capacity = 200,
                            IsAvailable = false,
                            ImageUrl = "https://st10490959.blob.core.windows.net/venueimages/venue2.jfif"
                        },
                         new Venue
                         {

                             VenueName = "City Hall",
                             Location = "325 City Center",
                             Capacity = 1200,
                             IsAvailable = true,
                             ImageUrl = "https://st10490959.blob.core.windows.net/venueimages/venue3.jfif"
                         }
                 };
            context.Venues.AddRange(venues);
            context.SaveChanges();


            var events = new List<Event>
            {

                new Event {  EventName = "IT Conference", Description = "Latest news on technology", EventDate = DateTime.Today.AddDays(10),   EventTypeId = 1,},
                new Event {   EventName = "Outdoor wedding", Description = "A beautiful wedding event", EventDate = DateTime.Today.AddDays(30),  EventTypeId = 4},
                new Event {   EventName = "Food Flea Market", Description = "All things good food event", EventDate = DateTime.Today.AddDays(15),  EventTypeId = 2}

            };
                
                context.Events.AddRange(events);
                context.SaveChanges();


            // Seed Bookings
            var bookings = new List<Booking>
            {

                    new Booking
                {
                    BookingDate = DateTime.Today,
                    EventDate = events[0].EventDate,
                    VenueId = venues[0].VenueId,
                    EventId = events[0].EventId
                },
                new Booking
                {
                    BookingDate = DateTime.Today.AddDays(-5),
                     EventDate = events[1].EventDate,
                    VenueId = venues[1].VenueId,
                    EventId = events[1].EventId
                },
                 new Booking
                {
                    BookingDate = DateTime.Today.AddDays(-5),
                     EventDate = events[2].EventDate,
                    VenueId = venues[2].VenueId,
                    EventId = events[2].EventId
                }
                };
            context.Bookings.AddRange(bookings);

            context.SaveChanges();
      
        }
    }
}

