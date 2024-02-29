using ETicaretApi.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ETicaretApi.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        //Defterde ki notlarini oku , burasi veritabani islemleri icin bir customization class'dir
        //IRepository temelde base tanimlamalari tutsun , yani butun repositroylerde olmasi gerekenleri tutsun ve miras versin

        //Irepository generic olmasi icin buraya bi <T> parametresi vericez bu <T> parametresi bir entite karsilik geliyor , ayrica <T> where : class bu <T> parametresi kural geriye class olmali biz de o sekilde tanimlamak zorundayiz
        DbSet<T> Table { get; } // Dbset proporty'si Table'a karsilik geliyor ve DbSette bir tek get islemi yapilir, set yapilmaz.


    }

}
