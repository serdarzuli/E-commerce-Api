﻿using ETicaretApi.Application.Repositories;
using ETicaretApi.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Persistence.Repositories
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {

        public ProductReadRepository(ETicaretAPIDbContext context) : base(context) { }

    }
}
