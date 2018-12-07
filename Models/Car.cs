using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenBridgeWebApi.Models
{
    public partial class Car
    {
        public Car()
        {
            Rides = new HashSet<Ride>();
        }
        [Key]
        public int Idcar { get; set; }
        
        [ForeignKey("User")]
        [Column("IDUser")]
        public int Iduser { get; set; }
        public string CarNumber { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
        public virtual User User { get; set; }
        public ICollection<Ride> Rides { get; set; }
    }
}
