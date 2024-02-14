using ETicaretApi.Domain.Entities.Common;
using ETicaretApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; } //entityframworke'a CustomerId'yi manul verdik ve o Customer ile iliskilendirecektir
        public string? Description { get; set; }
        public string? Address { get; set; }  //siparis bazli addressi belirleyebilelim diye Orderda adresi tanimladik , musterilerin tek tek adressi tutmayacagiz

        public ICollection<Product>? products { get; set; } //n-n ilisli oldugu icin 
        public Customer? Customer { get; set; } //1-n iliski 
    }
}
