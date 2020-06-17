using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using AutoMapper;
using DAL.UnitOfWork;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using BLL.Services.Impl;
using BLL.Services.Interfaces;
using CCL.Security.Identity;
using CCL.Security;

namespace BLL.Tests
{
    public class RoutesListServiceTests
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgummentNullException()
        {
            IUnitOfWork nullUnitOfWork = null;

            Assert.Throws<ArgumentNullException>(() => new RoutesListService(nullUnitOfWork));
        }
       
        [Fact]
        public void GetRoutesList_UsersIsAdmin_ThrowMethodAccessException()
        {
            User user = new Admin(1, "test name", "test surname", 1);
            SecurityContext.SetUser(user);
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            IRoutesListService routesListService = new RoutesListService(mockUnitOfWork.Object);

            Assert.Throws<MethodAccessException>(() => routesListService.GetRoutesList(0));
        }


        [Fact]
        public void GetRoutesList_RoutesListFromDAL_CorrectMappingToRoutesListDTO()
        {
            User user = new Moderator(1, "test name", "test surname", 1);
            SecurityContext.SetUser(user);
            var routtesListService = GetRoutesListService();

            var actualRoutesListDTO = routtesListService.GetRoutesList(0).GetEnumerator().Current;

            Assert.True(actualRoutesListDTO.RouteId == 1 && 
                actualRoutesListDTO.Name == "testName" && 
                actualRoutesListDTO.Content == "testContent");
        }



        IRoutesListService GetRoutesListService()
        {
            var mockContext = new Mock<IUnitOfWork>();
            var expectedRoutesList = new UnitRoute()
            {
                RouteId = 1,
                Name = "testName",
                Content = "testContent"
            };

            var mockDbSet = new Mock<IRoutesRepository>();
            mockDbSet.Setup(z => z.Find(It.IsAny<Func<UnitRoute, bool>>(), It.IsAny<int>(), It.IsAny<int>())).Returns(new List<UnitRoute>() { expectedRoutesList });
            mockContext.Setup(context => context.RouteLists).Returns(mockDbSet.Object);

            IRoutesListService routesListService = new RoutesListService(mockContext.Object);

            return routesListService;
        }
    }
}
