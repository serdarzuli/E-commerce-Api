using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretApi.Application.Abstractions.Services;
using ETicaretApi.Application.Repositories;
using ETicaretApi.Application.ViewModels;
using ETicaretApi.Domain.Entities;
using ETicaretApi.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ETicaretApi.Persistence.Services
{
    public class BasketServices : IBasketService
    {
        //1.26 dk da kaldim 52.ders

        //program.cs de Claimtypes.Name propertysi bize kullanicnin bilgilerini veriyor, 
        //1. kullanici var mi diye bakarim,
        //2. kullanici varsa, basketine bakarim,
        //3. O basket veya basketlardan, order olmayan basketlari alirim
        //4. ve o basket uzerinde gereken calismalari yaparim yani asagidaki calismalari

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly IOrderReadRepository _orderReadRepository;

        public BasketServices(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IOrderReadRepository orderReadRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _orderReadRepository = orderReadRepository;
        }
           
        public Task<List<BasketItem>> GetBasketItemAsync()
        {
            // Ben hangi basket itemlari getiricem? bunu client bilemez.
            // Reuqst atildiginda aktif olan basketi elde edecegiz ve onun altinda ki basket itemlari elde etmwmiz gerekiyor
            throw new NotImplementedException();
        }

        public Task AddItemToBasketAsync(VM_Create_BasketItem basketItem)
        {
            
            throw new NotImplementedException();
        }

        public Task UpdateQuantityAsync(VM_Update_BasketItem basketItem)
        {
            //aktif olan hangi basket id diye client bunu bilemez, ondan dilayi bizde VM_Update_BasketItem modulu yarattik 
            throw new NotImplementedException();
        }

        public Task RemoveBasketItemAsync(string basketItemId)
        {
            throw new NotImplementedException();
        }
    }
}
