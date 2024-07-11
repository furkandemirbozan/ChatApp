using AutoMapper;
using ChatApp.Data.Entities;
using ChatApp.Data.Models;
using ChatApp.Services.Models.User;
using ChatApp.Services.Services.Users;
using ChatAppWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatAppWebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;

        private readonly IMapper _mapper;

        public UserController(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ReturnModel> Get([FromQuery] PaginationModel paginationModel)
        {
            var users = await _userServices.ListAllAsync(paginationModel);
            return new ReturnModel
            {
                Success = true,
                Message = "Success",
                Data = _mapper.Map<List<UserModel>>(users),
                StatusCode = 200,
                TotalCount=await _userServices.CountAsync()
            };
        }
        [HttpGet("{id}")]
        public async Task<ReturnModel> Get(int id)
        {
            var user=await _userServices.GetByIdAsync(id);
            return new ReturnModel
            {
                Success = true,
                Message="Success",
                Data = user,
                StatusCode = 200
            };
        }
        [HttpPost]
        public async Task<ReturnModel> Post([FromBody] UserCreateModel userCreateModel)
        {
            var newUserr = _mapper.Map<User>(userCreateModel);
            var newUser=await _userServices.AddAsync(newUserr);
            return new ReturnModel
            {
                Success = true,
                Message = "User Created successfully",
                Data = newUser,
                StatusCode = 201
            };
        }
        [HttpPut]
        public async Task<ReturnModel> Put([FromBody]UserUpdateModel userModel)
        {
            var user =_mapper.Map<User>(userModel);
            var updateUser=await _userServices.UpdateAsync(user);
            return new ReturnModel
            {
                Success = true,
                Message = " User updated Successfully",
                Data = _mapper.Map<UserModel>(updateUser),
                StatusCode = 200
            };
        }
        [HttpDelete]
        public async Task<ReturnModel> Delete(int id)
        {
            var user =await _userServices.GetByIdAsync(id);
            await _userServices.DeleteAsync(user);
            return new ReturnModel
            {
                Success = true,
                Message = "User deleted successfully",
                StatusCode = 200
            };
        }
    }
}
