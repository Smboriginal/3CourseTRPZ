using System;
using System.Collections.Generic;
using System.Text;
using DAL.UnitOfWork;
using DAL.Repositories.Impl;
using DAL.Repositories.Interfaces;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class EFUnitOfWork
        : IUnitOfWork
    {
        //private readonly RoutesInfoSystemContext db;
        private RoutesInfoSystemContext db;
        private RouteInfoSystemRepository routeInfoSystemRepository;
        private RoutesListRepository routesListRepository;

        public EFUnitOfWork(DbContextOptions options)
        {
            db = new RoutesInfoSystemContext(options);
        }

        public IRepository<RouteInfoSystem> RouteInfoSystems
        {
            get
            {
                if (routeInfoSystemRepository == null)
                    routeInfoSystemRepository = new RouteInfoSystemRepository(db);
                return routeInfoSystemRepository;
            }
        }

        public IRepository<UnitRoute> RouteLists
        {
            get
            {
                if (routesListRepository == null)
                    routesListRepository = new RoutesListRepository(db);
                return routesListRepository;
            }
        }

        IRoutesInfoSystemRepository IUnitOfWork.RouteInfoSystems => throw new NotImplementedException();

        IRoutesRepository IUnitOfWork.RouteLists => throw new NotImplementedException();

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
