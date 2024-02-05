using ETicaretApi.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Persistence.Repositories
{
    public class CustomerReadRepository: ReadRepository<Customer> , ICustomerReadRepository
    {
        //Concrete sinifidir
        //Can alici noktaya geldik simdi biz burada ICustomerReadRepositorynin memberlarini ekle dersek o da zaten ReadRepositoryden alacaktir , o yuzden biz direkt ReadRepository<Customer> diyerek orada ki memberleri alicagiz.
        //DIKKAT : E NEDEN PEKI ICustomerReadRepositry diye bir interface yarattik dependecy injection icin , bu concret sinifin bir imzasi oldugunu kanitliyor ayrica  ReadRepository<Customer> , ICustomerReadRepository bu ikisi bir butundur anahtar kilit misali , ikisi kesinlikle yazmamiz gerekiyor ki istedgimiz gibi calissinalar , amac zaten design patternlari uygulamak yoksa diger turlu zaten kod yaziyoruz "" :)

        //Simdi gel gelelim ReadRepositorynin icine bakarsak orada constructoru bir tane deger istiyor context adinda bu context bizim entitye ozel database'de islem gerceklestirecektir o yuzden mecbur vermeliyiz nasil vericcez , bu class'a ait consturctor olusturup o degeri ReadRepositorynin constructoruna vericez, constructordan -> constructora :)

        public CustomerReadRepository(ETicaretAPIDbContext context) : base(context)
        {
            //bunun nesnesi bize IOC containerdan gelirken base'de burada ki nesneyi(contexti) gondermek zorundayiz.
        }

    }
}
