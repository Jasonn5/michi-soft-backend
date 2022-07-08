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
    public class BookingRepository : IBookingRepository
    {
        private readonly IdentityDbContext _dataAccess;

        public BookingRepository(IdentityDbContext dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Booking Add(Booking booking)
        {
            if (booking.ClassRoom != null)
            {
                var classRoom = _dataAccess.Set<ClassRoom>().Find(booking.ClassRoom.Id);

                if (classRoom != null)
                {
                    booking.ClassRoom = classRoom;
                }
            }

            if (booking.Matter != null)
            {
                var matter = _dataAccess.Set<Matter>().Find(booking.Matter.Id);

                if (matter != null)
                {
                    booking.Matter = matter;
                }
            }

            _dataAccess.Set<Booking>().Add(booking);
            _dataAccess.SaveChanges();

            return booking;
        }

        public ICollection<Booking> List(string search, DateTime date)
        {
            var result  = _dataAccess.Set<AllBooking>().FromSqlRaw($"dbo.GetBookings '{date.ToString("MM/dd/yyyy 00:00:00")}', '{date.ToString("MM/dd/yyyy 23:59:59")}','{search}'").AsEnumerable();

            var bookings = result.Select(r => new Booking
            {
                Id = r.Id,
                Date = r.Date,
                StartTime = r.StartTime,
                EndTime = r.EndTime,
                Reason = r.Reason,
                Matter = new Matter { Id = r.MatterId, Name = r.MatterName, Group = r.MatterGroup, User = new User { Id = r.UserId, FirstName = r.FirstName, LastName = r.LastName} },
                ClassRoom = new ClassRoom { Id = r.ClassroomId, Name = r.Name }
            });

            return bookings.ToList();
        }

        public ICollection<Booking> ListById(int professorId)
        {
            var result = _dataAccess.Set<BookingDetail>().FromSqlRaw($"dbo.BookingByProffesorId '{professorId}'").AsEnumerable();

            var bookings = result.Select(r => new Booking
            {
                Id = r.Id,
                Date = r.Date,
                StartTime = r.StartTime,
                EndTime = r.EndTime,
                Reason = r.Reason,
                Matter = new Matter { Id = r.MatterId, Name = r.MatterName, Group = r.MatterGroup },
                ClassRoom = new ClassRoom { Id = r.ClassRoomId, Name = r.ClassRoomName }
            });

            return bookings.ToList();
        }
    }
}
