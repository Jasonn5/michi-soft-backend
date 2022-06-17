using Entities;
using Entities.RequestParameters;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IBookingService
    {
        Booking Add(Booking booking);
        ICollection<Booking> ListById(int professorId);
        ICollection<Booking> List(BookingRequestParameters query);
    }
}
