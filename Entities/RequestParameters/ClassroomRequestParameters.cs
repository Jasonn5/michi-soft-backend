using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.RequestParameters
{
    [BindProperties]
    public class ClassroomRequestParameters
    {
        [BindProperty]
        public string Search { get; set; }
        public bool Active { get; set; }
    }
}
