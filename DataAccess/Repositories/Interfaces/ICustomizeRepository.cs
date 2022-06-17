using Entities;
using System.Collections.Generic;
namespace DataAccess.Repositories.Interfaces
{
    public interface ICustomizeRepository
    {
        Customize Add(Customize customize);
        void Update(Customize customize);
        Customize FindById(int id);
        Customize FindActualCustom();
        ICollection<Customize> List();
    }
}
