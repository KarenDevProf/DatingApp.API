namespace DatingApp.DAL.Models
{
    public class UserDish
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int DishId { get; set; }
        public Dish Dish { get; set; }
    }
}
