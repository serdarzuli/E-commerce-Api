using ETicaretApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T: BaseEntity
    {
        //Neden bu sekilde kendimiz customization yaptik , yarin sql den non sql'e gectik diyelim burada ki somut yapilanmalar yine calisacaktir.


        //yazma(insert,update,delete) ile ilgili islemler tanimlanacak
        //Alltaki kodlar IReadRepositoryde ki 1-4 kurallarini okuyarakda pekistirilebilir.

        //Neden bunlara boolen verdik , eklendiyse , guncellendiyse veya silindiyse sonucu true veya false donsun diye.
        //Istiyorsak ozel Ahmet diye bir sinif tasarlayip onuda dondurebiliriz :)
        Task<bool> AddAsync(T model); //Modelden kastimiz entitydir ve gelen tek entityi eklemektir, tekil islemdir
        Task<bool> AddRangeAsync(List<T> datas); // dikkat List<T> / Birden fazla entityi(datalar) eklemek icindir (koleksiyon gibi) , cogul islemdir

        bool Remove(T model);  //remove'in asyn yapisi  yoktur bunu bilelim ve olmadigi icin Task'ada ihtayac yokturr
        bool RemoveRange(List<T> datas); //birden cok datalari silmek icin
        Task<bool> RemoveAsync(string id); //Task denildigi zaman bir asenkron islemi oldugunu biliyoruz.    burada Task ile yapiyoruz cunku db arkaplanda id'yi gordugunde asenkron bir islem olarak onu gerceklestiriyor yani bundan dolayi bizde task yaziyoruz
        bool Update(T model);
        Task<int> SaveAsync(); // yapilan islemlerde savechnagesi cagirabilmem icin bu fonksiyonu kullanicaz

    }
}
