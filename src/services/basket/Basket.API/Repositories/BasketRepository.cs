using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {

        private readonly IDistributedCache _redisCahce;

        public BasketRepository(IDistributedCache redisCahce)
        {
            _redisCahce = redisCahce ?? throw new ArgumentNullException(nameof(redisCahce));
        }

        public async Task DeleteBasket(string username)
        {
             await _redisCahce.RemoveAsync(username);
        }

        public async Task<ShoppingCart> GetBasket(string username)
        {
            var basket = await _redisCahce.GetStringAsync(username);
            if(basket==null)
                return null;
            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            await _redisCahce.SetStringAsync(basket.Username,JsonConvert.SerializeObject(basket));
            return await GetBasket(basket.Username);
        }
    }
}
