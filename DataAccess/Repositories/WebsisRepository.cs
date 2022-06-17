using Authentication.Entities;
using DataAccess.Model;
using DataAccess.Repositories.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class WebsisRepository : IWebsisRepository
    {
        private readonly IdentityDbContext _dataAccess;

        public WebsisRepository(IdentityDbContext dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public ClassRoom AddClassRoom(ClassRoom classRoom)
        {
            _dataAccess.Set<ClassRoom>().Add(classRoom);
            _dataAccess.SaveChanges();

            return classRoom;
        }

        public ClassRoom GetClassRoomById(int id)
        {
            return _dataAccess.Set<ClassRoom>().Find(id);
        }

        public ClassRoom GetClassRoomByName(string name)
        {
            var classroom = _dataAccess.Set<ClassRoom>().FromSqlRaw($"dbo.GetClassroomByName '{name}'").AsEnumerable().FirstOrDefault();

            return classroom;
        }

        public IEnumerable<ClassRoom> GetClassRoomsByDate()
        {
            var classRooms = _dataAccess.Set<ClassRoom>().FromSqlRaw("dbo.GetAvailableClassroomsByDate").AsEnumerable();

            return classRooms;
        }

        public IEnumerable<Matter> GetMattersByTeacher(int teacherId)
        {
            var matters = _dataAccess.Set<Matter>().FromSqlRaw($"dbo.GetMattersByProffesor '{teacherId}'").AsEnumerable();
            foreach (var matter in matters)
            { 
                var result = _dataAccess.Set<MattersByProfessor>().FromSqlRaw($"dbo.GetClassroomSchedulesByMatter '{matter.Id}'").AsEnumerable();
                matter.ClassroomSchedules = result.Select(r => new ClassroomSchedule 
                {
                    Id = r.Id,
                    Day = r.Day,
                    StartHour = r.StartHour,
                    EndHour = r.EndHour,
                    ClassRoom = new ClassRoom { Id = r.ClassroomId, Name = r.ClassroomName }
                }).ToList();
            }

            return matters.ToList();
        }

        public ICollection<ClassRoom> ListClassRooms(string search, bool active)
        {
            int newActive = active ? 1 : 0;
            var classRooms = _dataAccess.Set<ClassRoom>().FromSqlRaw($"dbo.GetClassrooms '{search}', '{newActive}'").AsEnumerable();

            return classRooms.ToList();
        }

        public void Update(ClassRoom entity)
        {
            var ClassRoomToEdit = _dataAccess.Set<ClassRoom>().Find(entity.Id);

            ClassRoomToEdit.Type = entity.Type;
            ClassRoomToEdit.Capacity = entity.Capacity;
            ClassRoomToEdit.IsEnabled = entity.IsEnabled;
            _dataAccess.SaveChanges();
        }
    }
}
