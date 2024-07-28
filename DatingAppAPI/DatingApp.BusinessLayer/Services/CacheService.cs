using DatingApp.BusinessLayer.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using DatingApp.DAL.Models;
using DatingApp.BusinessLayer.Models.User.Request;
using System.Security.Cryptography;
using System.Text;

namespace DatingApp.BusinessLayer.Services
{
    public class CacheService : ICacheService
    {
        private readonly IUserService _user;
        private readonly IMemoryCache _memoryCache;

        private static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(10);

        public CacheService(IUserService user, IMemoryCache memoryCache)
        {
            _user = user;
            _memoryCache = memoryCache;
        }

        public async Task<List<User>> GetUsersByDish(UserDishRequest userDishRequest, bool shouldUpdateCache = false)
        {
            var cacheKey = GenerateCacheKey(userDishRequest);

            if (!shouldUpdateCache && _memoryCache.TryGetValue(cacheKey, out List<User> cachedUsersList))
            {
                return cachedUsersList;
            }

            var usersListResponse = await _user.GetUsersByDish(userDishRequest);
            if (usersListResponse.Any())
            {
                _memoryCache.Set(cacheKey, usersListResponse, CacheDuration);
            }

            return usersListResponse;
        }

        private string GenerateCacheKey(UserDishRequest userDishRequest)
        {
            var hashInput = $"{userDishRequest.Gender}-{userDishRequest.AgeFrom}-{userDishRequest.AgeTo}-{userDishRequest.DishName}";
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(hashInput));
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}