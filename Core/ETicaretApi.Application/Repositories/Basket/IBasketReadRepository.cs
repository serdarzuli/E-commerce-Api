using ETicaretApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Repositories
{
    public interface IBasketReadRepository : IReadRepository<Basket>
    {
        public DbSet<Basket> Table => throw new NotImplementedException();

        public IQueryable<Basket> GetAll(bool tracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<Basket> GetByIdAsync(string id, bool tracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<Basket> GetSingleAsync(System.Linq.Expressions.Expression<Func<Basket, bool>> method, bool tracking = true)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Basket> GetWhere(System.Linq.Expressions.Expression<Func<Basket, bool>> method, bool tracking = true)
        {
            throw new NotImplementedException();
        }
    }
}
