﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Features.Queries.GetAllProducts
{
    public class GetAllProductQueryResponse
    {
        public int TotalProductCount { get; set; }  
        public object Prdoucts { get; set; }
    }
}
