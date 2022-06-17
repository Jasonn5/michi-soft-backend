using Entities;
using System.Collections.Generic;

namespace DataAccess.Repositories.Interfaces
{
    public interface IWebsisRepository
    {
        IEnumerable<Matter> GetMattersByTeacher(int teacherId);
        IEnumerable<ClassRoom> GetClassRoomsByDate(); 
        ICollection<ClassRoom> ListClassRooms(string search, bool active);
        ClassRoom GetClassRoomById(int id);
        ClassRoom AddClassRoom(ClassRoom classRoom);
        ClassRoom GetClassRoomByName(string name);
        void Update(ClassRoom entity);
    }
}
