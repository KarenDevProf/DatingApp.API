using DatingApp.BusinessLayer.Enums;
using DatingApp.DAL.Models;

namespace DatingApp.BusinessLayer.Models.User.Request
{
    public class UpdateUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public List<string> FavoriteDishes { get; set; }
    }
}
