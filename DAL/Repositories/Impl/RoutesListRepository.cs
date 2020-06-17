using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.EF;

namespace DAL.Repositories.Impl
{
    public class RoutesListRepository
        : BaseRepository<SingleRoute>, IRoutesList
    {
        internal RoutesListRepository(RoutesSchemasSystemContext context)
            : base(context)
        {

        }
    }
}
