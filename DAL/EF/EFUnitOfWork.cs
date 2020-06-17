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
        //private readonly RoutesSchemasSystemContext db;
        private RoutesSchemasSystemContext db;
        private Repositories.Impl.RoutesSchemasSystemRepository eduInfoSystemRepository;
        private RoutesListRepository eduMaterialRepository;

        public EFUnitOfWork(DbContextOptions options)
        {
            db = new RoutesSchemasSystemContext(options);
        }

        public IRepository<RoutsListSystem> EduInfoSystems
        {
            get
            {
                if (eduInfoSystemRepository == null)
                    eduInfoSystemRepository = new Repositories.Impl.RoutesSchemasSystemRepository(db);
                return eduInfoSystemRepository;
            }
        }

        public IRepository<SingleRoute> EduMaterials
        {
            get
            {
                if (eduMaterialRepository == null)
                    eduMaterialRepository = new RoutesListRepository(db);
                return eduMaterialRepository;
            }
        }

        Repositories.Interfaces.IRoutesSchemasSystemRepository IUnitOfWork.RoutesListSystem => throw new NotImplementedException();

        IRoutesList IUnitOfWork.SigleRoute => throw new NotImplementedException();

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
