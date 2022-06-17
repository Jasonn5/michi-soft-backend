using Entities;
using Entities.RequestParameters;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IWebsisService
    {
        ICollection<ClassRoom> GetClassRoomsByDate();
        ICollection<Matter> GetMattersByTeacher(int teacherId);
        ICollection<ClassRoom> ListClassRooms(ClassroomRequestParameters query);
        void UpdateClassRoom(ClassRoom entity);
        ClassRoom GetClassRoomById(int id);
        ClassRoom AddClassRoom(ClassRoom classRoom);
    }
}
