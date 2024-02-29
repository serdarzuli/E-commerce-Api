using ETicaretApi.Application.Repositories;
using ETicaretApi.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ETicaretApi.Persistence.Repositories
{

    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        //Context nesnem olan ETicaretAPIDbContext nesnemi dependency injection IOC Container'ina zaten koymustuk ordan, burda talep edicez ve onun uzerinden gerekli write islemlerini gerceklestiriyor olucaz 


        private readonly ETicaretAPIDbContext _context;

        public WriteRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>(); //bu repositroynin db setini bu sekilde cagirdik.

        public async Task<bool> AddAsync(T model)
        {
            //Table.AddAsync(model); //AddAsync'nin uzerine giderek info kisminda bize bir Entity entry doncegini belirtiyor bizde o sekilde onu karsilamamiz lazim.
            EntityEntry<T> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added; //bu entityEntrynin bir state'i var , bu state'in bir enum'i var(Added diye) bu enuma turu ekleme mi, degil mi ? diye kontrolunu yapar ve  true ya da false donecektir.
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            //birden fazla veriyi eklmek.
            await Table.AddRangeAsync(datas);
            return true;
        }

        //NOOT: 
        //NEDEN removeun async'lisini yapmadik cunku kullandigimiz ORM(entityFramework)'da bile yalın hali olan Remove kullanmış doğal olarak bizde o şekilde kullanıyoruz.
        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry =  Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;

        }
        public bool RemoveRange(List<T> datas)
        {

            Table.RemoveRange(datas);
            return true;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            //id bazli arama yapicaz ondan sonra silicez
            T model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            //Table.Remove(model); bu sekilde de yapabiliriz ama yukarida remove fonksiyonu var oldugundan onu kullanmak daha guzel olur
            return Remove(model);
        }

        public bool Update(T model)
        {
            EntityEntry<T> entityEntry  =  Table.Update(model);
            return  entityEntry.State == EntityState.Modified;
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }


        #region RemoveByName
         //bunu yapamadik anlamsiz bir hata verir.
        //public Task<bool> RemoveAsyncByName(string name)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion


        //Simdi yapilanmamiz olmasi gerekn ideal repository desingn pattern sekilde insa edilmis oldu
        //Next step : 
        //artik yapilmasi gerekn tek sey kaldi entitylere uygun  interfacelerini ve concretelerini olusturmaktir

    }
}
