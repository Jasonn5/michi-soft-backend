using Microsoft.AspNetCore.Mvc;

namespace Authentication.Entities.RequestParameters
{
    [BindProperties]
    public class ProfessorRequestParameters
    {
        [BindProperty]
        public string Search { get; set; }
    }
}
