using ETicaretApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Repositories
{
    public interface IBasketItemReadRepository : IReadRepository<BasketItem>
    {
        public DbSet<BasketItem> Table => throw new NotImplementedException();

        public IQueryable<BasketItem> GetAll(bool tracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<BasketItem> GetByIdAsync(string id, bool tracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<BasketItem> GetSingleAsync(Expression<Func<BasketItem, bool>> method, bool tracking = true)
        {
            throw new NotImplementedException();
        }

        public IQueryable<BasketItem> GetWhere(Expression<Func<BasketItem, bool>> method, bool tracking = true)
        {
            throw new NotImplementedException();
        }
    }
}
