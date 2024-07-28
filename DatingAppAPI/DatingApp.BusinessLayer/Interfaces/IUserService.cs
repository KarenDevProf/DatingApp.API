using DatingApp.BusinessLayer.Models.User.Request;
using DatingApp.DAL.Models;

namespace DatingApp.BusinessLayer.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsersByDish(UserDishRequest userDishRequest);
        Task<User> CreateUserAsync(CreateUserRequest createUserRequest);
        Task<User> UpdateUserAsync(int id, UpdateUserRequest updateUserRequest);
    }
}
