using Authentication.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Booking : Entity
    {
        [Required]
        public Matter Matter { get; set; }

        [Required]
        public ClassRoom ClassRoom { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal StartTime { get; set; }

        [Required]
        public decimal EndTime { get; set; }

        public string Reason { get; set; }
    }
}
