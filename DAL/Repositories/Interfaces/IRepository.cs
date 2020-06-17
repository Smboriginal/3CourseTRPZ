using System;
using System.Collections.Generic;

namespace DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T: class
    {
        public IEnumerable<T> GetAll();
        public T Get(int id);        //test1
        public IEnumerable<T> Find(Func<T, bool> predicate, int pageNumber = 0, int pageSize = 1280);
        public void Create(T item);  //test2
        public void Update(T item); 
        public void Delete(int id);  //test3
    }
}
