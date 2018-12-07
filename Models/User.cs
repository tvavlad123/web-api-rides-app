using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenBridgeWebApi.Models
{
    public partial class User
    {
        public User()
        {
            Cars = new HashSet<Car>();
            UserRides = new HashSet<UserRide>();
        }
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }

        public ICollection<Car> Cars { get; set; }
        public ICollection<UserRide> UserRides { get; set; }
    }
}