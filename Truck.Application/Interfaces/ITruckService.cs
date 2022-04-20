using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truck.CrossCuting.Enum;

namespace Truck.Application.Interfaces
{
    public interface ITruckService
    {
        Task<IEnumerable<Domain.Models.Truck>> Get();
        Task<Domain.Models.Truck> Get(int id);
        Task<(Return status, string description)> Create(Domain.Models.Truck obj);
        Task<(Return status, string description)> Update(Domain.Models.Truck obj);
        Task<(Return status, string description)> Remove(int id);
    }
}
