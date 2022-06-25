using Microsoft.AspNetCore.Mvc;
using System;

namespace Entities.RequestParameters
{
    [BindProperties]
    public class AvailableClassroomsRequestParameters
    {
        [BindProperty]
        public decimal Starttime { get; set; }

        public decimal Endtime { get; set; }

        public DateTime Date { get; set; }

        public int Capacity { get; set; }

        public int Id { get; set; }
    }
}
