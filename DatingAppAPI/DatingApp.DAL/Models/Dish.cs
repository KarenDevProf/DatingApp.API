using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.DAL.Models
{
    public class Dish
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public virtual ICollection<Like> Likes { get; set; } = new List<Like>();
        public virtual ICollection<UserDish> UserDishes { get; set; } = new List<UserDish>();
    }
}
