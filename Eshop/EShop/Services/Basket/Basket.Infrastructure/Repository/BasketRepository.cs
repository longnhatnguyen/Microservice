using Basket.Core.Entities;
using Basket.Core.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Infrastructure.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _resdisCache;

        public BasketRepository(IDistributedCache resdisCache)
        {
            _resdisCache = resdisCache;
        }

        public async Task<bool> DeleteBasket(string userName)
        {
            await _resdisCache.RemoveAsync(userName);
            return true;
        }

        public async Task<ShoppingCart> GetBasket(string userName)
        {
            var basket = await _resdisCache.GetStringAsync(userName);
            if (string.IsNullOrEmpty(basket))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart shoppingCart)
        {
            await _resdisCache.SetStringAsync(shoppingCart.UserName, JsonConvert.SerializeObject(shoppingCart));
            return await GetBasket(shoppingCart.UserName);
        }
    }
}
