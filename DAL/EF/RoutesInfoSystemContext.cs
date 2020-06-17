using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public class RoutesInfoSystemContext
        : DbContext
    {
        public DbSet<RouteInfoSystem> Storage { get; set; }
        public DbSet<UnitRoute> Routes { get; set; }

        public RoutesInfoSystemContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
