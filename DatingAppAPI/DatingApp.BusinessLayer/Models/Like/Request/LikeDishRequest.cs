using System.ComponentModel.DataAnnotations;

namespace DatingApp.BusinessLayer.Models.Like.Request
{
    public class LikeDishRequest
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int DishId { get; set; }
    }
}
