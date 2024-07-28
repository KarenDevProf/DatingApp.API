using DatingApp.BusinessLayer.Models.Dish.Response;

namespace DatingApp.BusinessLayer.Models.User.Response
{
    public class UserResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public List<DishModel> FavoriteDishes { get; set; }
    }
}
