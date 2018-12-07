using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenBridgeWebApi.Models
{
    public partial class Ride
    {
        public Ride()
        {
            UserRides = new HashSet<UserRide>();
        }
        [Key]
        public int RideId { get; set; }
        
        [ForeignKey("Car")]
        public int CarId { get; set; }
        public DateTime DateTime { get; set; }
        public string StartLocation { get; set; }
        public string Destination { get; set; }
        public int FreeSeats { get; set; }
        public bool Cancelled { get; set; }

        public Car Car { get; set; }
        public ICollection<UserRide> UserRides { get; set; }
    }
}
