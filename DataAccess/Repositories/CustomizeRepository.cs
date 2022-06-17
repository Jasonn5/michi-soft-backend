using DataAccess.Repositories.Interfaces;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class CustomizeRepository : ICustomizeRepository
    {
        private readonly IdentityDbContext _dataAccess;

        public CustomizeRepository(IdentityDbContext dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public Customize Add(Customize customize)
        {
            _dataAccess.Set<Customize>().Add(customize);
            _dataAccess.SaveChanges();

            return customize;
        }

        public Customize FindActualCustom()
        {
            var customize = _dataAccess.Set<Customize>().FromSqlRaw("dbo.GetActualCustom").AsEnumerable().SingleOrDefault();

            return customize;
        }

        public Customize FindById(int id)
        {
            return _dataAccess.Set<Customize>().Find(id);
        }

        public ICollection<Customize> List()
        {
            var customizes = _dataAccess.Set<Customize>().FromSqlRaw("dbo.GetCustomizes").AsEnumerable();

            return customizes.ToList();
        }

        public void Update(Customize customize)
        {
            var customizeoEdit = _dataAccess.Set<Customize>()
                .SingleOrDefault(c => c.Id == customize.Id); 

            customizeoEdit.IsEnabled = false;

            _dataAccess.SaveChanges();
        }
    }
}
