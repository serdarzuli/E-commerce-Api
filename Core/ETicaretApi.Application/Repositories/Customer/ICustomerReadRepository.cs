using ETicaretApi.Domain.Entities;

namespace ETicaretApi.Application.Repositories //namesapce repositories.customer olmasi lazim ama biz sildik cunku hataya aliyoruz Customer entitysine erisemiyoruz
{

    //artik generic olmayacak interfacelerimiz direkt customer olacak cunku bu generic olmasi gereken bir yapilanma degil bu customer bir yapilanma olmasini istiyoruz
    public interface ICustomerReadRepository : IReadRepository<Customer>
    {
        //simdi biz bu sekilde IreadRepository<customer> dedigimiz de bizim ICustomerReadRepositorymiz , miras aldigi interfacein icerisinde ki memberlara erismis vve onlari kullanmis olacagiz.

    }
}
