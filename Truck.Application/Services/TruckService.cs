using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truck.Application.Interfaces;
using Truck.CrossCuting.Enum;
using Truck.CrossCuting;
using Truck.Domain.Interfaces;

namespace Truck.Application.Services
{
    public class TruckService : ITruckService
    {
        private readonly ITruckRepository _truckRepository;

        public TruckService(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }

        public async Task<IEnumerable<Domain.Models.Truck>> Get()
        {
            IEnumerable<Domain.Models.Truck> list = await _truckRepository.Get();
            return list;
        }

        public async Task<Domain.Models.Truck> Get(int id)
        {
            var obj = await _truckRepository.Get(id);
            return obj;
        }

        public async Task<(Return status, string description)> Create(Domain.Models.Truck obj)
        {
            if (obj.IdModel != 1 && obj.IdModel != 2)
                return (Return.error, ResourcesCrossCuting.msgModel);

            if (obj.YearFabrication != DateTime.Today.Year)
                return (Return.error, ResourcesCrossCuting.msgFabricationYear);

            if (obj.YearModel < DateTime.Today.Year || obj.YearModel > DateTime.Today.Year + 1)
                return (Return.error, ResourcesCrossCuting.msgModelYear);

            await _truckRepository.Create(obj);
            return (Return.added, "Ok");
        }        

        public async Task<(Return status, string description)> Update(Domain.Models.Truck obj)
        {
            if (obj.IdModel != 1 && obj.IdModel != 2)
                return (Return.error, ResourcesCrossCuting.msgModel);

            if (obj.YearModel < obj.YearFabrication || obj.YearModel > obj.YearFabrication + 1)
                return (Return.error, ResourcesCrossCuting.msgModelYear);

            var _obj = await _truckRepository.Get(obj.IdTruck);

            if (_obj == null)
                return (Return.error, ResourcesCrossCuting.msgRegisterNotFound);

            _obj.Description = obj.Description;
            _obj.IdModel = obj.IdModel;
            _obj.YearModel = obj.YearModel;

            await _truckRepository.Update(_obj);
            return (Return.changed, "Ok");
        }

        public async Task<(Return status, string description)> Remove(int id)
        {
            var obj = await _truckRepository.Get(id);

            if (obj == null)
                return (Return.error, ResourcesCrossCuting.msgRegisterNotFound);

            await _truckRepository.Remove(obj);
            return (Return.deleted, "Ok");
        }
    }
}
