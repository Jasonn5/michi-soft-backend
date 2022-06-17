using System;

namespace Entities
{
    public class Customize : Entity
    {
        public DateTime DateOfCustom { get; set; }
        public int Minimum { get; set; }

        public int Maximum { get; set; }

        public string Reason { get; set; }

        public bool IsEnabled { get; set; }
    }
}
