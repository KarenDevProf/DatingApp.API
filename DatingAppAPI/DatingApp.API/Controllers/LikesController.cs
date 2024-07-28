using Microsoft.AspNetCore.Mvc;
using DatingApp.BusinessLayer.Models.Like.Request;
using DatingApp.BusinessLayer.Interfaces;
using DatingApp.API.Models;
using DatingApp.BusinessLayer.Models.Like.Response;
using DatingApp.DAL.Models;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikesController : DatingAppBaseController
    {
        private readonly DatingAppContext _context;
        private readonly ILikeService _likeService;

        public LikesController(IDatingAppServices services) : base(services)
        {
            _likeService = services.GetService<ILikeService>();
        }


        [HttpPost]
        public async Task<ResponseObjectModel<LikeDishResponse>> LikeDish([FromBody] LikeDishRequest request)
        {
            ResponseObjectModel<LikeDishResponse> responseObject = new ResponseObjectModel<LikeDishResponse>();
            CheckModelState();
            var likeDish = await _likeService.LikeDishAsync(request);
            responseObject.Data = Mapper.Map<LikeDishResponse>(likeDish);
            return responseObject;
        }
    }
}
