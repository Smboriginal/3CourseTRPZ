using DAL.Repositories.Impl;
using DAL.Entities;
using DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace DAL.Tests
{
    public class TestRoutesListRepository
        : BaseRepository<SingleRoute>
    {
        public TestRoutesListRepository(DbContext context)
            : base(context)
        {

        }
    }
}
