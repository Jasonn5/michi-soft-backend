using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Model
{
    public class AllBooking
    {
        public int Id { get; set; }
        public int ClassroomId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public decimal StartTime { get; set; }
        public decimal EndTime { get; set; }
        public string Reason { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MatterId { get; set; }
        public string MatterName { get; set; }
        public string MatterGroup { get; set; }
    }
}
