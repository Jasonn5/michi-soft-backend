using Entities;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        Booking Add(Booking booking);
        ICollection<Booking> ListById(int professorId); 
        ICollection<Booking> List(string search, DateTime date);
    }
}
