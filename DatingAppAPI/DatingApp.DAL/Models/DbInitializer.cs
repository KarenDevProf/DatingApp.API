using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DatingApp.DAL.Models
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DatingAppContext>();

                if (context != null)
                {
                    context.Database.Migrate();

                    context.Database.EnsureCreated();

                    if (!context.Users.Any())
                    {
                        var users = new List<User>()
                        {
                            new User { Email = "user1@example.com", FirstName = "John", LastName = "Doe", Age = 30, Gender = 0 },
                            new User { Email = "user2@example.com", FirstName = "Jane", LastName = "Doe", Age = 25, Gender = 1 },
                            new User { Email = "user3@example.com", FirstName = "Jim", LastName = "Beam", Age = 40, Gender = 0 },
                            new User { Email = "user4@example.com", FirstName = "Jack", LastName = "Daniels", Age = 35, Gender = 0 },
                            new User { Email = "user5@example.com", FirstName = "Jill", LastName = "Stuart", Age = 28, Gender = 1 }
                        };

                        context.Users.AddRange(users);
                        context.SaveChanges();
                    }

                    if (!context.Dishes.Any())
                    {
                        var dishes = new List<Dish>()
                        {
                            new Dish { Name = "Pizza" },
                            new Dish { Name = "Sushi" },
                            new Dish { Name = "Burger" },
                            new Dish { Name = "Pasta" },
                            new Dish { Name = "Salad" }
                        };

                        context.Dishes.AddRange(dishes);
                        context.SaveChanges();
                    }

                    if (!context.Likes.Any())
                    {
                        var likes = new List<Like>()
                        {
                            new Like { UserId = 1, DishId = 1 },
                            new Like { UserId = 1, DishId = 2 },
                            new Like { UserId = 2, DishId = 3 },
                            new Like { UserId = 2, DishId = 4 },
                            new Like { UserId = 3, DishId = 5 },
                            new Like { UserId = 4, DishId = 1 },
                            new Like { UserId = 4, DishId = 3 },
                            new Like { UserId = 5, DishId = 4 },
                            new Like { UserId = 5, DishId = 5 }
                        };

                        context.Likes.AddRange(likes);
                        context.SaveChanges();
                    }

                    if (!context.UserDishes.Any())
                    {
                        var userDishes = new List<UserDish>()
                        {
                            new UserDish { UserId = 1, DishId = 1 },
                            new UserDish { UserId = 1, DishId = 2 },
                            new UserDish { UserId = 2, DishId = 3 },
                            new UserDish { UserId = 2, DishId = 4 },
                            new UserDish { UserId = 3, DishId = 5 },
                            new UserDish { UserId = 4, DishId = 1 },
                            new UserDish { UserId = 4, DishId = 3 },
                            new UserDish { UserId = 5, DishId = 4 },
                            new UserDish { UserId = 5, DishId = 5 }
                        };

                        context.UserDishes.AddRange(userDishes);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
