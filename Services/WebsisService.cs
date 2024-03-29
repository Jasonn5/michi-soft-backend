﻿using DataAccess.Repositories.Interfaces;
using Entities;
using Entities.RequestParameters;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class WebsisService : IWebsisService
    {
        private readonly IWebsisRepository _websisRepository;

        public WebsisService(IWebsisRepository websisRepository)
        {
            _websisRepository = websisRepository;
        }

        public ClassRoom AddClassRoom(ClassRoom classRoom)
        {
            var result = _websisRepository.GetClassRoomByName(classRoom.Name);
            if (result != null)
            {
                
                throw new ApplicationException("Ya existe un ambiente registrado con ese nombre");
            }
            else 
            {
                return _websisRepository.AddClassRoom(classRoom);
            }
        }

        public ClassRoom GetClassRoomById(int id)
        {
            var classRoom = _websisRepository.GetClassRoomById(id);

            return classRoom;
        }

        public ICollection<ClassRoom> GetClassRoomsByDate(AvailableClassroomsRequestParameters query)
        {
            var classRooms = _websisRepository.GetClassRoomsByDate(query.Starttime, query.Endtime,query.Date, query.Capacity);

            return classRooms.ToList();
        }

        public ClassRoom GetAvailableClassRoom(AvailableClassroomsRequestParameters query)
        {
            var classRooms = _websisRepository.GetAvailableClassRoom(query.Starttime, query.Endtime, query.Date, query.Id);
            if (classRooms != null)
            {

                throw new ApplicationException("Tu aula la esta reservada, Te sugerimos estas otras:");
            }
            else
            {
                return classRooms;
            }
        }

        public ICollection<ClassroomSchedule> GetClassroomSchedulesByMatter(int matterId)
        {
            var classroomSchedules = _websisRepository.GetClassroomSchedulesByMatter(matterId);

            return classroomSchedules.ToList();
        }

        public ICollection<Matter> GetMattersByTeacher(int teacherId)
        {
            var matters = _websisRepository.GetMattersByTeacher(teacherId);

            return matters.ToList();
        }

        public ICollection<ClassRoom> ListClassRooms(ClassroomRequestParameters query)
        {
            var classRooms = _websisRepository.ListClassRooms(query.Search, query.Active);
            classRooms = classRooms.OrderByDescending(c => c.Capacity).ToList();

            return classRooms;
        }

        public void UpdateClassRoom(ClassRoom entity)
        {
            _websisRepository.Update(entity);
        }
    }
}
