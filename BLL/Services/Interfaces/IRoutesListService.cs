using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IRoutesListService
    {
        IEnumerable<RoutesListDTO> GetRoutesList(int page);
    }
}
