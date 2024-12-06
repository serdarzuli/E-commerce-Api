using ETicaretApi.Domain.Entities.Common;
using ETicaretApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Domain.Entities
{
    public class Customer : BaseEntity
    {
                 public ICollection<Order>? Orders { get; set; }
    }
}
