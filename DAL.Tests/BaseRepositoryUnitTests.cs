using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using DAL.EF;


namespace DAL.Tests
{
    public class BaseRepositoryUnitTests
    {
        [Fact]
        public void Create_InputEducationMaterialInstance_CalledAddMethodOfDBSetWithEducationMaterialInstance()
        {
            DbContextOptions opt = new DbContextOptionsBuilder<RoutesSchemasSystemContext>().Options;
            var mockContext = new Mock<RoutesSchemasSystemContext>(opt);
            var mockDbSet = new Mock<DbSet<SingleRoute>>();
            mockContext.Setup(context => context.Set<SingleRoute>()).Returns(mockDbSet.Object);
            var repository = new TestRoutesListRepository(mockContext.Object);
            SingleRoute expectedEducationMaterial = new Mock<SingleRoute>().Object;

            repository.Create(expectedEducationMaterial);

            mockDbSet.Verify(dbSet => dbSet.Add(expectedEducationMaterial), Times.Once());
        }


        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            DbContextOptions opt = new DbContextOptionsBuilder<RoutesSchemasSystemContext>().Options;
            var mockContext = new Mock<RoutesSchemasSystemContext>(opt);
            var mockDbSet = new Mock<DbSet<SingleRoute>>();
            mockContext.Setup(context => context.Set<SingleRoute>()).Returns(mockDbSet.Object);


            SingleRoute expectedEducationMaterial = new SingleRoute() { SingleRouteId = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedEducationMaterial.SingleRouteId)).Returns(expectedEducationMaterial);
            var repository = new TestRoutesListRepository(mockContext.Object);

            var actualEducationMaterial = repository.Get(expectedEducationMaterial.SingleRouteId);

            mockDbSet.Verify(dbSet => dbSet.Find(expectedEducationMaterial.SingleRouteId), Times.Once());
            Assert.Equal(expectedEducationMaterial, actualEducationMaterial);
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            DbContextOptions opt = new DbContextOptionsBuilder<RoutesSchemasSystemContext>().Options;
            var mockContext = new Mock<RoutesSchemasSystemContext>(opt);
            var mockDbSet = new Mock<DbSet<SingleRoute>>();
            mockContext.Setup(context => context.Set<SingleRoute>()).Returns(mockDbSet.Object);
            var repository = new TestRoutesListRepository(mockContext.Object);

            SingleRoute expectedEducationMaterial = new SingleRoute() { SingleRouteId = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedEducationMaterial.SingleRouteId)).Returns(expectedEducationMaterial);

            repository.Delete(expectedEducationMaterial.SingleRouteId);

            mockDbSet.Verify(dbSet => dbSet.Find(expectedEducationMaterial.SingleRouteId), Times.Once());

            mockDbSet.Verify(dbSet => dbSet.Remove(expectedEducationMaterial), Times.Once());
        }
    }
}
