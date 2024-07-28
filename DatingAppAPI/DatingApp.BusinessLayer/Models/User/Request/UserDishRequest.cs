using System.ComponentModel.DataAnnotations;
using DatingApp.BusinessLayer.Attributes;
using DatingApp.BusinessLayer.Enums;

namespace DatingApp.BusinessLayer.Models.User.Request
{
    public class UserDishRequest
    {
        [Required]
        public Gender Gender { get; set; }

        [EitherAgeFromOrAgeToRequired]
        public int AgeFrom { get; set; }

        [EitherAgeFromOrAgeToRequired]
        public int AgeTo { get; set; }
        public string DishName { get; set; }
    }
}
