using ETicaretApi.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
    {
        //Read ile ilgili islemler tanimlanacak , read'den kasit Select'tir baska bir sey degildir.
        //Veritabanindan sorgu neticesinde data elde ediceksek biz buna read islemleri diycez\
        //Read islemleri ne sekilde olabilir
        //1.Tum datalari elde etmek olabilir.
        //2.Sartli veri godnerip sarta uyan verilerin donmesini isteyebilirim. 
        //3.sartli veri gonderip sarta uyan tek verinin donmesini isteyebilirim
        //4. Id gonderip (Niye id cunku id unique oldugundan) o id'ye uyan verinin elde edilmesini isteyebilirim. vs diye bunlari interface olarak tanimlayalim
        //Genellikle 4 tanedir fazla da olabilir ama genel olarak bu 4 tanedir
        //Veritabaninda nasil bir fantazi uyguluyorsan ,uyguladigin fantaziyi burada modelleyeceksin :)

        //Irepositoryden miras alacak herhangi bir entity verebilirim (product,order,customer) ama ben daha generic bir yapi istiyorum o yuzden <T> olarak veriyorum onlarca,yuzlerce entityim olabilir, bunlari Concrete katmaninda belirticem

        //IQueryable<T> cogul verileri icin kullanilir , Tekil veriler icin ise sadece T tanimi kullaniriz asagida ornek var.
        IQueryable<T> GetAll(bool tracking= true);
        //IQueryable sorguda calismak istedigim icindir
        //ve bu <T> ne ? bu T paramtresi herhangi bir entity olabilir, product order customer vs.
        //GetAll() nedir , hangi entity verirsek o entitiynin nevar neyoku varsa bana getirsindir
        //List IEnumerable'dir , in memory'e ceker butun verileri onun uzerinde islem yapmamizi saglar

        //IQueryable olan sorgularda, senin yazmis oldugun where sartlari ya da select sorgulari vs ilgili veritabani sorgusuna eklenecektir 
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true); //method yerine ahmette yazabilirim, bu lambda operatru gibi davranir.
        //bu GetWhere() ne anlama gelir ? bir sart vericem bu sarta uygun 'birden fazla' (cogul) veri elde edilsin

        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
        //Bu sefer de Sarta uygun olan tek veriyi getiricek bana

        Task<T> GetByIdAsync(string id, bool tracking = true);
        //Concrette bunu ekleycegiz
        //Marker gibi yapilanmalari kullanarak id bazli calismlari daha basit hale getirebiliriz
        //marker, base entity ya da Ientity gibi  base turlerden istifade edebiliriz 
        //reflaction'da  6 saat ugrasarak maliyet kaybederek zaman harcayamaya gerek yok 
        //Arka planda Asenkron olarak calistiklari icin T GetById() =>> Task<T> GetBYIdAsync() olarak duzenledik
        //Bu sefer id'ye uygun olan sart hangisiyse o id'yi(veriyi) getiricek.



    }
}
