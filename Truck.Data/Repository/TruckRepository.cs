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
    public class TruckRepository : ITruckRepository
    {
        private readonly DataContext _context;

        public TruckRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Models.Truck>> Get()
        {
            return await _context.Truck
                            .Include(p => p.ModelTruck)
                            .OrderBy(p => p.Description)
                            .ToListAsync();
        }

        public async Task<Domain.Models.Truck> Get(int id)
        {
            var user = await _context.Truck
                                .Include(p => p.ModelTruck)
                                .FirstOrDefaultAsync(p => p.IdTruck == id);
            return user;
        }

        public async Task Create(Domain.Models.Truck obj)
        {
            await _context.Truck.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(Domain.Models.Truck obj)
        {
            _context.Truck.Remove(obj);
            await _context.SaveChangesAsync();
        }        

        public async Task Update(Domain.Models.Truck obj)
        {
            _context.Update(obj);
            await _context.SaveChangesAsync();
        }
    }
}
