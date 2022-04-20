using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Truck.Domain.Models;

namespace Truck.Data.Context
{
    public class DataContext : DbContext
    {
        public virtual DbSet<ModelTruck> ModelTruck { get; set; } = null!;

        public virtual DbSet<Domain.Models.Truck> Truck { get; set; } = null!;

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //builder.Conventions.Remove<PluralizingTableNameConvention>();

            //Fks
            builder.Entity<ModelTruck>()
                        .HasMany(p => p.Trucks)
                        .WithOne(p => p.ModelTruck)
                        .HasForeignKey(p => p.IdModel)
                        .IsRequired();

            #region Seed data

            var modelsTruck = new List<ModelTruck>
            {
                new ModelTruck { IdModel = 1, Model = "FH" },
                new ModelTruck { IdModel = 2, Model = "FM"},
                new ModelTruck { IdModel = 3, Model = "Outer"}
            };

            builder.Entity<ModelTruck>().HasData(modelsTruck);
            

            #endregion

            base.OnModelCreating(builder);

        }


    }
}
