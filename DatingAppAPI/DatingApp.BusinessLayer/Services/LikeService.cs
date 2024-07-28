using DatingApp.BusinessLayer.Exceptions;
using DatingApp.BusinessLayer.Interfaces;
using DatingApp.BusinessLayer.Models.Like.Request;
using DatingApp.DAL.Models;
using DatingApp.Repositories.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.BusinessLayer.Services
{
    public class LikeService : ILikeService
    {
        private readonly IRepository<Like> _likeRepository;

        public LikeService(IRepository<Like> likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<Like> LikeDishAsync(LikeDishRequest likeDishRequest)
        {
            var existingLike = await _likeRepository.FindBy(l => l.UserId == likeDishRequest.UserId
                                                                 && l.DishId == likeDishRequest.DishId)
                .FirstOrDefaultAsync();

            if (existingLike != null)
            {
                throw new HasAlreadyLikeException();
            }

            var like = new Like
            {
                UserId = likeDishRequest.UserId,
                DishId = likeDishRequest.DishId
            };

            await _likeRepository.AddAsync(like);
            await _likeRepository.SaveChangesAsync();

            return like;
        }
    }
}
