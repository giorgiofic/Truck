using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Truck.Data.Context;
using Truck.Domain.Interfaces;

namespace Truck.Data.Repository
{
    public class ModelTruckRepository : IModelTruckRepository
    {
        private readonly DataContext _context;

        public ModelTruckRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Models.ModelTruck>> Get()
        {
            return await _context.ModelTruck
                            .OrderBy(p => p.Model)
                            .ToListAsync();
        }
    }
}
