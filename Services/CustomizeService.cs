using DataAccess.Repositories.Interfaces;
using Entities;
using Services.Helpers;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services
{
    public class CustomizeService : ICustomizeService
    {
        private readonly ICustomizeRepository _customizeRepository;

        public CustomizeService(ICustomizeRepository customizeRepository)
        {
            _customizeRepository = customizeRepository;
        }


        public Customize FindActualCustom()
        {
            return _customizeRepository.FindActualCustom();
        }

        public ICollection<Customize> List()
        {
            var customizes = _customizeRepository.List();

            return customizes;
        }

        public void Update(Customize customize)
        {
            var result = _customizeRepository.FindById(customize.Id);

            if (result != null)
            {
                _customizeRepository.Update(customize);
                var newCustomize = new Customize()
                {
                    DateOfCustom = TimeZoneHelper.GetSaWesternStandardTime(),
                    Minimum = customize.Minimum,
                    Maximum = customize.Maximum,
                    Reason = customize.Reason,
                    IsEnabled = true
                };

                _customizeRepository.Add(newCustomize);
            }
        }
    }
}
