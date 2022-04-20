using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truck.Domain.Interfaces
{
    public interface ITruckRepository
    {
        Task<IEnumerable<Models.Truck>> Get();
        Task Create(Models.Truck obj);
        Task<Models.Truck> Get(int id);
        Task Update(Models.Truck obj);
        Task Remove(Models.Truck obj);
    }
}
