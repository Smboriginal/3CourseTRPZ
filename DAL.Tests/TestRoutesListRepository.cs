using DAL.Repositories.Impl;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Tests
{
    public class TestRoutesListRepository
        : BaseRepository<UnitRoute>
    {
        public TestRoutesListRepository(DbContext context)
            : base(context)
        {

        }
    }
}
