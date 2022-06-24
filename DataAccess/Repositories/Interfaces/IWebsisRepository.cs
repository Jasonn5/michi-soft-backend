using Entities;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories.Interfaces
{
    public interface IWebsisRepository
    {
        IEnumerable<Matter> GetMattersByTeacher(int teacherId);
        IEnumerable<ClassRoom> GetClassRoomsByDate(decimal startTime, decimal endTime, DateTime date, int capacity); 
        ICollection<ClassRoom> ListClassRooms(string search, bool active);
        ClassRoom GetClassRoomById(int id);
        ClassRoom GetAvailableClassRoom(decimal startTime, decimal endTime, DateTime date);
        ICollection<ClassroomSchedule> GetClassroomSchedulesByMatter(int matterId);
        ClassRoom AddClassRoom(ClassRoom classRoom);
        ClassRoom GetClassRoomByName(string name);
        void Update(ClassRoom entity);
    }
}
