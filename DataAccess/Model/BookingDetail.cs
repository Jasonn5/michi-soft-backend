using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Model
{
    public class BookingDetail
    {
        public int Id { get; set; }
        public int MatterId { get; set; }
        public string MatterName { get; set; }
        public string MatterGroup { get; set; }
        public int ClassRoomId { get; set; }
        public string ClassRoomName { get; set; }
        public DateTime Date { get; set; }
        public decimal StartTime { get; set; }
        public decimal EndTime { get; set; }
        public string Reason { get; set; }
    }
}
