using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRoutesInfoSystemRepository RouteInfoSystems { get; }
        IRoutesRepository RouteLists { get; }
        void Save();
    }
}
