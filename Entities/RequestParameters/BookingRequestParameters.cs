using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.RequestParameters
{
    [BindProperties]
    public class BookingRequestParameters
    {
        [BindProperty]
        public string Search { get; set; }
    }
}
