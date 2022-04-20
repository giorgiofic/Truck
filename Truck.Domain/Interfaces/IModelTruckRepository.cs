using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truck.Domain.Interfaces
{
    public interface IModelTruckRepository
    {
        Task<IEnumerable<Models.ModelTruck>> Get();        
    }
}
