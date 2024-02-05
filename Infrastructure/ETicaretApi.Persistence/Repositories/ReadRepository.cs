using ETicaretApi.Application.Repositories;
using ETicaretApi.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        //Context nesnem olan ETicaretAPIDbContext nesnemi dependency injection IOC Container'ina zaten koymustuk ordan, burda talep edicez ve onun uzerinden gerekli read islemlerini gerceklestiriyor olucaz 

        private readonly ETicaretAPIDbContext _context;

        public ReadRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }


        public DbSet<T> Table => _context.Set<T>(); //Set bizden bir entity istiyor biz de T parametreli (herhangi bir) entity veriyoruz

        #region Tracking uygulamasi
        //Dbcontext araciyla veritabaninda cektigimiz butun datalari tracking trafaindan takibe aliniyor ve datanin uzerine yapilan degisikleri meknizama anliyor ,default olarak true'dur
        //ben 1000 adet data cektim diyelim , ama uzerinde degiisklik yapmayacagim o zaman neden track edioyr bu bi maliyettir
        //misal track edilecek datalar ,databeseden bize gelen verilerin update ve delete islmlerini daha kolay analiz etmek icin track edebiliriz.
        #endregion
        public IQueryable<T> GetAll(bool tracking = true) //=> Table; //Table ,DbSettir e DbSettir'da T'ye uygun bir sekilde IQueryable oldugundan dolayi generictir  burada geriye direkt Table dondurulebilecektir.
        {
            var query = Table.AsQueryable(); // AsQueryable'in return degeri IQueryable'dir bundan dolayi hata almiyoruz.
            if(!tracking)                       //tracking false'a 
                query = query.AsNoTracking();
            return query;


        }



        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        //=> Table.Where(method); //.where description'ni okudugumuzda bizden bir Expression ,func ve bool'en istiyor bizde parametre olarak bunu metoda verdik bu sekilde sorunsuz calisiyor.
        {
            var query = Table.Where(method);
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;

        }



        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        //=> await Table.FirstOrDefaultAsync(method);
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query.FirstOrDefault(method);
        }




        #region Marker Pattern ille GetByIdAsync yapisi
        //getbyId gibi generic yapilanmalarinda merker pattern'i kullanicaz , getById gibi degersel calismalarda calismak istiyorsak o degeri temsil eden bir arayuz veyya bir sinif tasarlamamiz gerekiyor.
        //Marker pattern, marker yani isaretleyici mantiginda kullanilan Interface veya BaseEntity(BaseClasslar) ise misal InterFace olur butun entityleri IEntity diye interfaceinden turuyordur o da olabilir veya bizim burada yaptigimiz gibi de olabilir BaseEntity gibi. bu mantikta calisan bir sinifim varsa marker pattern denir buna , generic yapilanmayi o sinifa ozel olusturur,
        //yani kisacasi :
        //public class ReadRepository<T> : IReadRepository<T> where T : class ===>
        //public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity     ayni sekilde bunlari Interfacelerde de duzeltmek lazim.
        //bize sart konulmustu class olacak diye bizde bir sart koyuyoruz daha da daraltiyoruz BaseEntity classi olsun diyoruz neden cunku butun entitylerde ortak olan fieldlar BaseEntityde var e bu da ne anlama geliyor , butun entiyilere hitap ediyor demektir , e biz napiyoruz generic bir yapilanma yapiyoruz yani butun entiyleri temsil edecek bir yapilanma e bu degisiklik'de bu yapilanmaya uyuyor.

        //asagidaki de ayni isi gorur ama daha zehmetli alternatif olarak yazdik
        //=> await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id)); //Guid.parse vermis oldugumuz stringi guide parse etmis oalcaktir
        //Bizim markerimiz BaseEntityiddir
        //Marker gibi yapilanmalari kullanarak id bazli calismlari daha basit hale getirebiliriz
        //marker, base entity(var) ya da IEntity(varsa) gibi  base turlerden istifade edebiliriz 


        #endregion
        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            //Cok onemli not IQueryable ile calisiyorsak FindAsync metoduna bu durumda marker patterni kullancagiz

            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query.FirstOrDefault(data => data.Id == Guid.Parse(id)); //bu marker patterndir 
        }

          //  metod() => await Table.FindAsync(Guid.Parse(id)); //yukarida ve asagidaki billgiler alternaitf yapi icindir , bu yapi hazir bir mettod olarakdir ve asenkron olarak calisir ve id'yi bazli sorgulama yapar . trackingsiz olan kisim


        

        
    }
}
