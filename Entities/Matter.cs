using Authentication.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Matter : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int NumberStudents { get; set; }

        [Required]
        public string Group { get; set; }

        [Required]
        public User User { get; set; }

        public ICollection<ClassroomSchedule> ClassroomSchedules { get; set; }
    }
}
