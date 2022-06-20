using Authentication.Entities;
using DataAccess.Model;
using DataAccess.Repositories.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class WebsisRepository : IWebsisRepository
    {
        private readonly IdentityDbContext _dataAccess; 
        //public readonly string _configuration;

        public WebsisRepository(IdentityDbContext dataAccess, IConfiguration configuration)
        {
            _dataAccess = dataAccess;
            //this._configuration = configuration.GetConnectionString("MichisoftDatabase");
        }

        public ClassRoom AddClassRoom(ClassRoom classRoom)
        {
            _dataAccess.Set<ClassRoom>().Add(classRoom);
            _dataAccess.SaveChanges();

            return classRoom;
        }

        public ClassRoom GetClassRoomById(int id)
        {
            return _dataAccess.Set<ClassRoom>().Find(id);
        }

        public ClassRoom GetClassRoomByName(string name)
        {
            var classroom = _dataAccess.Set<ClassRoom>().FromSqlRaw($"dbo.GetClassroomByName '{name}'").AsEnumerable().FirstOrDefault();

            return classroom;
        }

        public IEnumerable<ClassRoom> GetClassRoomsByDate(decimal startTime, decimal endTime, DateTime date, int capacity)
        {
            //using (SqlConnection sql = new SqlConnection(_configuration))
            //{
            //    using (SqlCommand cmd = new SqlCommand("dbo.GetAvailableClassroomsByDate", sql))
            //    {
            //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //        cmd.Parameters.Add(new SqlParameter("@StartTime", startTime));
            //        cmd.Parameters.Add(new SqlParameter("@EndTime", endTime));
            //        cmd.Parameters.Add(new SqlParameter("@StartDate", date.ToString("MM/dd/yyyy 00:00:00")));
            //        cmd.Parameters.Add(new SqlParameter("@EndDate", date.ToString("MM/dd/yyyy 23:59:59")));
            //        cmd.Parameters.Add(new SqlParameter("@Capacity ", capacity));

            //        var products = new List<ClassRoom>();
            //        sql.Open();

            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                products.Add(MapToProduct(reader));
            //            }
            //        }
            //        sql.Close();
            //        return products.ToList();
            //    }


            //}
            var classRooms = _dataAccess.Set<ClassRoom>().FromSqlRaw($"dbo.GetAvailableClassroomsByDate '{startTime}', '{endTime}', '{date.ToString("MM/dd/yyyy 00:00:00")}', '{date.ToString("MM/dd/yyyy 23:59:59")}', {capacity}").AsEnumerable();

            return classRooms;
        }

        public IEnumerable<Matter> GetMattersByTeacher(int teacherId)
        {
            var matters = _dataAccess.Set<Matter>().FromSqlRaw($"dbo.GetMattersByProffesor '{teacherId}'").AsEnumerable();
            foreach (var matter in matters)
            { 
                var result = _dataAccess.Set<MattersByProfessor>().FromSqlRaw($"dbo.GetClassroomSchedulesByMatter '{matter.Id}'").AsEnumerable();
                matter.ClassroomSchedules = result.Select(r => new ClassroomSchedule 
                {
                    Id = r.Id,
                    Day = r.Day,
                    StartHour = r.StartHour,
                    EndHour = r.EndHour,
                    ClassRoom = new ClassRoom { Id = r.ClassroomId, Name = r.ClassroomName }
                }).ToList();
            }

            return matters.ToList();
        }

        public ICollection<ClassRoom> ListClassRooms(string search, bool active)
        {
            int newActive = active ? 1 : 0;
            var classRooms = _dataAccess.Set<ClassRoom>().FromSqlRaw($"dbo.GetClassrooms '{search}', '{newActive}'").AsEnumerable();

            return classRooms.ToList();
        }

        public void Update(ClassRoom entity)
        {
            var ClassRoomToEdit = _dataAccess.Set<ClassRoom>().Find(entity.Id);

            ClassRoomToEdit.Type = entity.Type;
            ClassRoomToEdit.Capacity = entity.Capacity;
            ClassRoomToEdit.IsEnabled = entity.IsEnabled;
            _dataAccess.SaveChanges();
        }

        //private ClassRoom MapToProduct(SqlDataReader reader)
        //{
        //    return new ClassRoom()
        //    {
        //        Id = (int)reader["id"],
        //        Name = reader["Name"].ToString(),
        //        Type = (int)reader["Type"],
        //        Capacity = (int)reader["Capacity"],
        //        IsEnabled = (bool)reader["IsEnabled"],
        //    };
        //}
    }
}
