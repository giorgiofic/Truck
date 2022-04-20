using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truck.CrossCuting.Enum;

namespace Truck.Application.Interfaces
{
    public interface IModelTruckService
    {
        Task<IEnumerable<Domain.Models.ModelTruck>> Get();        
    }
}
