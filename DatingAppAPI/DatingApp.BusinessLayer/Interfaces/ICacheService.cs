using DatingApp.BusinessLayer.Models.User.Request;
using DatingApp.DAL.Models;

namespace DatingApp.BusinessLayer.Interfaces
{
    public interface ICacheService
    {
        Task<List<User>> GetUsersByDish(UserDishRequest userDishRequest, bool shouldUpdateCache = false);
    }
}
