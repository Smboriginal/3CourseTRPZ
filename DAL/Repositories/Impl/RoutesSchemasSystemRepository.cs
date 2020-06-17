using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.EF;

namespace DAL.Repositories.Impl
{
    public class RoutesSchemasSystemRepository
        : BaseRepository<RoutsListSystem>, Interfaces.IRoutesSchemasSystemRepository
    {
        internal RoutesSchemasSystemRepository(RoutesSchemasSystemContext context)
            : base(context)
        {
        }
    }
}
