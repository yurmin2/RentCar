using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentCar.Models;

namespace RentCar.Data
{
    public class RentCarContext : DbContext
    {
        public RentCarContext (DbContextOptions<RentCarContext> options)
            : base(options)
        {
        }

        public DbSet<RentCar.Models.LeaseAgreement> LeaseAgreement { get; set; } = default!;
        public DbSet<RentCar.Models.Car> Car { get; set; } = default!;
        public DbSet<RentCar.Models.Tenant> Tenant { get; set; } = default!;
    }
}
