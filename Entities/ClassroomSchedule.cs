namespace Entities
{
    public class ClassroomSchedule : Entity
    {
        public int Day { get; set; }
        public decimal StartHour { get; set; }
        public decimal EndHour { get; set; }

        public ClassRoom ClassRoom { get; set; }
    }
}
