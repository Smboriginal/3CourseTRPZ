using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using DAL.EF;
using DAL.Entities;

namespace DAL.Tests
{
    public class BaseRepositoryUnitTests
    {
        [Fact]
        public void Create_InputEducationMaterialInstance_CalledAddMethodOfDBSetWithEducationMaterialInstance()
        {
            DbContextOptions opt = new DbContextOptionsBuilder<RoutesInfoSystemContext>().Options;
            var mockContext = new Mock<RoutesInfoSystemContext>(opt);
            var mockDbSet = new Mock<DbSet<UnitRoute>>();
            mockContext.Setup(context => context.Set<UnitRoute>()).Returns(mockDbSet.Object);
            var repository = new TestRoutesListRepository(mockContext.Object);
            UnitRoute expectedEducationMaterial = new Mock<UnitRoute>().Object;

            repository.Create(expectedEducationMaterial);

            mockDbSet.Verify(dbSet => dbSet.Add(expectedEducationMaterial), Times.Once());
        }


        [Fact]
        public void Get_InputId_CalledFindMethodOfDBSetWithCorrectId()
        {
            DbContextOptions opt = new DbContextOptionsBuilder<RoutesInfoSystemContext>().Options;
            var mockContext = new Mock<RoutesInfoSystemContext>(opt);
            var mockDbSet = new Mock<DbSet<UnitRoute>>();
            mockContext.Setup(context => context.Set<UnitRoute>()).Returns(mockDbSet.Object);


            UnitRoute expectedEducationMaterial = new UnitRoute() { RouteId = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedEducationMaterial.RouteId)).Returns(expectedEducationMaterial);
            var repository = new TestRoutesListRepository(mockContext.Object);

            var actualEducationMaterial = repository.Get(expectedEducationMaterial.RouteId);

            mockDbSet.Verify(dbSet => dbSet.Find(expectedEducationMaterial.RouteId), Times.Once());
            Assert.Equal(expectedEducationMaterial, actualEducationMaterial);
        }

        [Fact]
        public void Delete_InputId_CalledFindAndRemoveMethodsOfDBSetWithCorrectArg()
        {
            DbContextOptions opt = new DbContextOptionsBuilder<RoutesInfoSystemContext>().Options;
            var mockContext = new Mock<RoutesInfoSystemContext>(opt);
            var mockDbSet = new Mock<DbSet<UnitRoute>>();
            mockContext.Setup(context => context.Set<UnitRoute>()).Returns(mockDbSet.Object);
            var repository = new TestRoutesListRepository(mockContext.Object);

            UnitRoute expectedEducationMaterial = new UnitRoute() { RouteId = 1 };
            mockDbSet.Setup(mock => mock.Find(expectedEducationMaterial.RouteId)).Returns(expectedEducationMaterial);

            repository.Delete(expectedEducationMaterial.RouteId);

            mockDbSet.Verify(dbSet => dbSet.Find(expectedEducationMaterial.RouteId), Times.Once());

            mockDbSet.Verify(dbSet => dbSet.Remove(expectedEducationMaterial), Times.Once());
        }
    }
}
