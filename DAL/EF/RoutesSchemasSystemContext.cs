using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public class RoutesSchemasSystemContext
        : DbContext
    {
        public DbSet<RoutsListSystem> UniteDesk { get; set; } //unitesyst for all storages
        public DbSet<SingleRoute> Routes { get; set; }  //routes

        public RoutesSchemasSystemContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
