using DatingApp.BusinessLayer.Exceptions;
using DatingApp.BusinessLayer.Interfaces;
using DatingApp.BusinessLayer.Models.User.Request;
using DatingApp.DAL.Models;
using DatingApp.Repositories.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Dish> _dishRepository;

        public UserService(IRepository<User> userRepository, IRepository<Dish> dishRepository)
        {
            _userRepository = userRepository;
            _dishRepository = dishRepository;
        }

        public async Task<List<User>> GetUsersByDish(UserDishRequest userDishRequest)
        {
            var usersByDishList = await _userRepository.GetAll()
                .Include(u => u.UserDishes)
                .ThenInclude(ud => ud.Dish)
                .Where(u =>
                    (userDishRequest.AgeFrom <= 0 || u.Age >= userDishRequest.AgeFrom) &&
                    (userDishRequest.AgeTo <= 0 || u.Age <= userDishRequest.AgeTo) &&
                    u.Gender == (int)userDishRequest.Gender &&
                    u.UserDishes.Any(ud => ud.Dish.Name == userDishRequest.DishName))
                .AsNoTracking()
                .ToListAsync();

            return usersByDishList;
        }

        public async Task<User> CreateUserAsync(CreateUserRequest createUserRequest)
        {
            var isFreeEmail = await IsFreeEmail(createUserRequest.Email.ToLower());
            if (!isFreeEmail)
            {
                throw new EmailUsedException();
            }
            
            var user = new User()
            {
                Email = createUserRequest.Email,
                FirstName = createUserRequest.FirstName,
                LastName = createUserRequest.LastName, 
                Age = createUserRequest.Age,
                Gender = (int)createUserRequest.Gender
            };

            var newUser = await _userRepository.AddAsync(user);

            await _userRepository.SaveChangesAsync();

            return newUser;
        }

        public async Task<User> UpdateUserAsync(int id, UpdateUserRequest updateUserRequest)
        {
            var user = await _userRepository.FindBy(e => e.Id == id)
                .Include(u => u.UserDishes)
                .ThenInclude(u => u.Dish)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new NotFoundException();
            }

            user.FirstName = updateUserRequest.FirstName;
            user.LastName = updateUserRequest.LastName;
            user.Gender = (int)updateUserRequest.Gender;
            user.Age = updateUserRequest.Age;

            user.UserDishes.Clear();

            foreach (var dishName in updateUserRequest.FavoriteDishes)
            {
                var existingDish = await _dishRepository.FindBy(d => d.Name == dishName).FirstOrDefaultAsync();
                if (existingDish == null)
                {
                    existingDish = new Dish { Name = dishName };
                    await _dishRepository.AddAsync(existingDish);
                    await _dishRepository.SaveChangesAsync();
                }
                user.UserDishes.Add(new UserDish { User = user, Dish = existingDish });
            }

            await _userRepository.SaveChangesAsync();
            return user;
        }

        private async Task<bool> IsFreeEmail(string email)
        {
            return await _userRepository.FindBy(e => e.Email == email).FirstOrDefaultAsync() == null;
        }

    }
}
