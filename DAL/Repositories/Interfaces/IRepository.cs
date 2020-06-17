﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public IEnumerable<T> GetAll();
        public T Get(int id);
        public IEnumerable<T> Find(Func<T, Boolean> predicate);
        public void Create(T item);
        public void Update(T item);
        public void Delete(int id);
    }
}
