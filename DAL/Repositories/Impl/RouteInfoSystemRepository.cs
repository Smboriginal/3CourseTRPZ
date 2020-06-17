using DAL.Entities;
using DAL.Repositories.Interfaces;
using DAL.EF;

namespace DAL.Repositories.Impl
{
    public class RouteInfoSystemRepository
        : BaseRepository<RouteInfoSystem>, IRoutesInfoSystemRepository
    {
        internal RouteInfoSystemRepository(RoutesInfoSystemContext context)
            : base(context)
        {
        }
    }
}
