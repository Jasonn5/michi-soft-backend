using Entities;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MIchi_Soft_Backend.Controllers
{
    [Authorize]
    [Route("api/websis")]
    [ApiController]
    public class WebsisController : MainController
    {
        private readonly IWebsisService _websisService;

        public WebsisController(IWebsisService websisService)
        {
            _websisService = websisService;
        }

        [HttpGet]
        [Route("matter/{proffesorId}")]
        public ActionResult<ICollection<Matter>> GetMatterByProffersor(int proffesorId)
        {
            return Ok(_websisService.GetMattersByTeacher(proffesorId));
        }

        [HttpGet]
        [Route("available-classrooms")]
        public ActionResult<ICollection<Matter>> GetAvailableClassrooms([FromQuery] AvailableClassroomsRequestParameters query)
        {
            return Ok(_websisService.GetClassRoomsByDate(query));
        }

        [HttpPost]
        [Route("classrooms")]
        public ActionResult<ICollection<ClassRoom>> Add(ClassRoom classRoom)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("\n", ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage)).ToArray());

                return BadRequest(errors);
            }
            var newClassRoom = _websisService.AddClassRoom(classRoom);

            return Created("api/classRooms", newClassRoom);
        }

        [HttpGet]
        [Route("classrooms")]
        public ActionResult<ICollection<Matter>> GetClassrooms([FromQuery] ClassroomRequestParameters query)
        {
            return Ok(_websisService.ListClassRooms(query));
        }

        [HttpGet]
        [Route("classrooms/{id}")]
        public ActionResult<ICollection<Matter>> GetClassroomById(int id)
        {
            return Ok(_websisService.GetClassRoomById(id));
        }

        [HttpPatch]
        [Route("classroom/{id}")]
        public ActionResult<ClassRoom> Update(ClassRoom classRoom)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("\n", ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage)).ToArray());

                return BadRequest(errors);
            }

            _websisService.UpdateClassRoom(classRoom);

            return Ok(classRoom);
        }
    }
}
