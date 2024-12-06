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
                                      throw new NotImplementedException();
        }

        public Task AddItemToBasketAsync(VM_Create_BasketItem basketItem)
        {
            
            throw new NotImplementedException();
        }

        public Task UpdateQuantityAsync(VM_Update_BasketItem basketItem)
        {
                         throw new NotImplementedException();
        }

        public Task RemoveBasketItemAsync(string basketItemId)
        {
            throw new NotImplementedException();
        }
    }
}
