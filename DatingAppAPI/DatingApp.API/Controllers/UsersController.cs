using DatingApp.API.Models;
using DatingApp.BusinessLayer.Interfaces;
using DatingApp.BusinessLayer.Models.User.Request;
using DatingApp.BusinessLayer.Models.User.Response;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : DatingAppBaseController
    {
        private readonly IUserService _userService;
        private readonly ICacheService _cacheService;

        public UsersController(IDatingAppServices services, ICacheService cacheService) : base(services)
        {
            _userService = services.GetService<IUserService>();
            _cacheService = cacheService;
        }

        [HttpGet]
        public async Task<ResponseObjectModel<List<UserResponse>>> GetUsersByDish([FromQuery] UserDishRequest userDishRequest)
        {
            ResponseObjectModel<List<UserResponse>> responseObject = new ResponseObjectModel<List<UserResponse>>();
            var users = await _cacheService.GetUsersByDish(userDishRequest);
            responseObject.Data = Mapper.Map<List<UserResponse>>(users);
            return responseObject;
        }
        
        [HttpPost]
        public async Task<ResponseObjectModel<UserResponse>> CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            ResponseObjectModel<UserResponse> responseObject = new ResponseObjectModel<UserResponse>();
            CheckModelState();

            var createdUser = await _userService.CreateUserAsync(createUserRequest);

            responseObject.Data = Mapper.Map<UserResponse>(createdUser);
            return responseObject;
        }


        [HttpPut("{id}")]
        public async Task<ResponseObjectModel<UserResponse>> UpdateUser(int id, [FromBody] UpdateUserRequest updateUserRequest)
        {
            ResponseObjectModel<UserResponse> responseObject = new ResponseObjectModel<UserResponse>();
            CheckModelState();
            var updatedUser = await _userService.UpdateUserAsync(id, updateUserRequest);
            responseObject.Data = Mapper.Map<UserResponse>(updatedUser);
            return responseObject;
        }

    }
}
