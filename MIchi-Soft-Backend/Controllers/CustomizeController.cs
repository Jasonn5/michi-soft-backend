using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MIchi_Soft_Backend.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/customize")]
    [ApiController]
    public class CustomizeController : MainController
    {
        private readonly ICustomizeService _customizeService;

        public CustomizeController(ICustomizeService customizeService)
        {
            _customizeService = customizeService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<ICollection<Customize>> Get()
        {
            return Ok(_customizeService.List());
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("actual-custom")]
        public ActionResult<ICollection<Customize>> GetActualCustom()
        {
            return Ok(_customizeService.FindActualCustom());
        }

        [HttpPatch]
        [Route("{id}")]
        public ActionResult<Customize> Update(Customize customize)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("\n", ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage)).ToArray());

                return BadRequest(errors);
            }

            _customizeService.Update(customize);

            return Ok(customize);
        }
    }
}
