using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EventEaseWebApp.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        [Display(Name = "Booking Date")]
        [DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }

        [Required]
        [Display(Name = "Venue")]
        public int VenueId { get; set; }
        public Venue Venue { get; set; }

        [Required]
        [Display(Name = "Event")]
        public int EventId { get; set; }
        public Event Event { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }
    }
}
