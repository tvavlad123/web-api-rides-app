using System;
using System.Collections.Generic;

namespace GreenBridgeWebApi.Models
{
    public partial class UserRide
    {
        public int UserId { get; set; }
        public int RideId { get; set; }
        public int? Rating { get; set; }
        public string Comment { get; set; }

        public Ride Ride { get; set; }
        public User User { get; set; }
    }
}
