using Microsoft.AspNetCore.Identity;

namespace ETicaretApi.Domain.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        //public string NameSurname { get; set; }

        public string? RefreshToken { get; set; }
        public ICollection<Basket> Baskets { get; set; }
    }
}
