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
    public class ModelTruckService : IModelTruckService
    {
        private readonly IModelTruckRepository _modeltruckRepository;

        public ModelTruckService(IModelTruckRepository modelTruckRepository)
        {
            _modeltruckRepository = modelTruckRepository;
        }

        public async Task<IEnumerable<Domain.Models.ModelTruck>> Get()
        {
            IEnumerable<Domain.Models.ModelTruck> list = await _modeltruckRepository.Get();
            return list;
        }
    }
}
