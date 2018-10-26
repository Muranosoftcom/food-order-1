using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IRepository
    {
        IQueryable<T> All<T>() where T : Entity;
        T GetById<T>(int id) where T : Entity;
        Task Insert<T>(T entity) where T : Entity;
        Task Insert<T>(IEnumerable<T> entities) where T : Entity;
        void Delete<T>(T entity) where T : Entity;
        void Update<T>(T entity) where T : Entity;
        Task Save();
    }
}