using System;
using System.Collections.Generic;
using System.Text;
using BLL.Services.Interfaces;
using DAL.UnitOfWork;
using BLL.DTO;
using CCL.Security;
using CCL.Security.Identity;
using DAL.Entities;
using AutoMapper;

namespace BLL.Services.Impl
{
    public class RoutesListService
        : IRoutesListService

    {
        public readonly IUnitOfWork _database;
        public int pageSize = 10;

        public RoutesListService(IUnitOfWork unitOfWork)
        {
            if(unitOfWork == null)
            {
                throw new ArgumentNullException(nameof(unitOfWork));
            }
            _database = unitOfWork;
        }

        public IEnumerable<RoutesListDTO> GetRoutesList(int pageNumber)
        {
            var user = SecurityContext.GetUser();
            var userType = user.GetType();
            if(userType != typeof(Admin) && userType != typeof(Moderator))
            {
                throw new MethodAccessException();
            }

            var routeId = user.RouteId;
            var unitRouteEntities = _database.RouteLists.Find(z => z.RouteId == routeId, pageNumber, pageSize);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UnitRoute, RoutesListDTO>()).CreateMapper();
            var materialsDTO = mapper.Map<IEnumerable<UnitRoute>, List<RoutesListDTO>>(unitRouteEntities);
            return materialsDTO;
        }
    }
}
