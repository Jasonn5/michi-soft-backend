using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Model
{
    public class MattersByProfessor
    {
        public int ClassroomId { get; set; }
        public string ClassroomName { get; set; }
        public int Id { get; set; }
        public string Day { get; set; }
        public decimal StartHour { get; set; }
        public decimal EndHour { get; set; }
    }
}
