using ETicaretApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Repositories
{
    public interface IBasketWriteRepository : IWriteRepository<Basket>
    {
        public DbSet<Basket> Table => throw new NotImplementedException();

        public Task<bool> AddAsync(Basket model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddRangeAsync(List<Basket> datas)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Basket model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRange(List<Basket> datas)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public bool Update(Basket model)
        {
            throw new NotImplementedException();
        }
    }
}
