using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface ICustomizeService
    {
        void Update(Customize customize);
        Customize FindActualCustom();
        ICollection<Customize> List();
    }
}
