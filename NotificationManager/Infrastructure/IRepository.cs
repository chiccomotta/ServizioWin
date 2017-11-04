using System.Collections.Generic;

namespace NotificationManager.Infrastructure
{
    public interface IRepository<T, in K> where T : IEntity<K>
    {
        IEnumerable<T> List { get; }
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T FindById(K Id);
    }
}