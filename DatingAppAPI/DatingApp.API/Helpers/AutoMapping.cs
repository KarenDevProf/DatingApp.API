using AutoMapper;
using DatingApp.BusinessLayer.Enums;
using DatingApp.BusinessLayer.Models.Dish.Response;
using DatingApp.BusinessLayer.Models.Like.Response;
using DatingApp.BusinessLayer.Models.User.Response;
using DatingApp.DAL.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.FavoriteDishes, opt => opt.MapFrom(src => src.UserDishes.Select(ud => ud.Dish)))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => ((Gender)src.Gender).ToString()));

            CreateMap<Dish, DishModel>();
            CreateMap<Like, LikeDishResponse>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.DishId, opt => opt.MapFrom(src => src.DishId));
        }
    }
}
