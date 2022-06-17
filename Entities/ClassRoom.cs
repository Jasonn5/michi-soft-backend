using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class ClassRoom : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Type { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public bool IsEnabled { get; set; }
    }
}
