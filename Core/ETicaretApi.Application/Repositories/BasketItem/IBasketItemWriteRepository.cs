using ETicaretApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Repositories
{
    public interface IBasketItemWriteRepository : IWriteRepository<BasketItem>
    {
        public DbSet<BasketItem> Table => throw new NotImplementedException();

        public Task<bool> AddAsync(BasketItem model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddRangeAsync(List<BasketItem> datas)
        {
            throw new NotImplementedException();
        }

        public bool Remove(BasketItem model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRange(List<BasketItem> datas)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public bool Update(BasketItem model)
        {
            throw new NotImplementedException();
        }
    }
}
