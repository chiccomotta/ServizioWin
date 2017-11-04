using NotificationManager.Database;
using NotificationManager.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace NotificationManager.Models
{
    public class CustomersRepository : IRepository<Customer, int>
    {
        private readonly RegulatoryDbContext _dbContext;

        public CustomersRepository()
        {
            _dbContext = new RegulatoryDbContext();
        }

        public IEnumerable<Customer> List
        {
            get { return _dbContext.Customers; }
        }

        public void Add(Customer entity)
        {
            _dbContext.Customers.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Customer entity)
        {
            _dbContext.Customers.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update(Customer entity)
        {
            _dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public Customer FindById(int Id)
        {
            var result = (from r in _dbContext.Customers where r.Id == Id select r).FirstOrDefault();
            return result;
        }
    }
}
