using DataAccess.Repositories.Interfaces;
using Entities;
using Entities.RequestParameters;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public Booking Add(Booking booking)
        {
            return _bookingRepository.Add(booking);
        }

        public ICollection<Booking> List(BookingRequestParameters query)
        {
            var bookings = _bookingRepository.List(query.Search);

            return bookings.ToList();
        }

        public ICollection<Booking> ListById(int professorId)
        {
            var bookings = _bookingRepository.ListById(professorId);

            return bookings.ToList();
        }
    }
}
