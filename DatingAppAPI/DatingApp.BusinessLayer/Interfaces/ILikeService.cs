using DatingApp.BusinessLayer.Models.Like.Request;
using DatingApp.BusinessLayer.Models.User.Request;
using DatingApp.DAL.Models;

namespace DatingApp.BusinessLayer.Interfaces
{
    public interface ILikeService
    {
        Task<Like> LikeDishAsync(LikeDishRequest likeDishRequest);
    }
}
