using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRoutesSchemasSystemRepository RoutesListSystem { get; }
        IRoutesList SigleRoute { get; }
        void Save();
    }
}
