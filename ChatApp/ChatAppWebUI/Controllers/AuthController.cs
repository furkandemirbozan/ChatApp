using AutoMapper;
using ChatApp.Data.Entities;
using ChatApp.Services.Helpers;
using ChatApp.Services.Models;
using ChatApp.Services.Models.User;
using ChatApp.Services.Services.Users;
using ChatAppWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ChatAppWebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AuthController : Controller
    {
        private readonly IUserServices _userServices;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public AuthController(IUserServices userServices, IConfiguration configuration, IMapper mapper)
        {
            _userServices = userServices;
            _configuration = configuration;
            _mapper = mapper;
        }
        [HttpPost("login")]
        public async Task<ReturnModel> Login([FromBody] LoginModel loginModel)
        {
            var user= await _userServices.GetByUserNameAndPasswordAsync(loginModel.UserName, loginModel.Password);
            if (user==null)
            {
                return new ReturnModel
                {
                    Success = false,
                    Message = "Invalid username or password",
                    StatusCode = 400
                };
            }
            var tokenModel = new TokenModel
            {
                Username = user.UserName,
                Role = user.Role,
                SigninKey = _configuration["Jwt:SigningKey"],
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };
            var token= JwtToken.GenerateToken(tokenModel);
            return new ReturnModel
            {
                Success = true,
                Message = "Login Successful",
                Data = token,
                StatusCode = 200
            };
        }
        [HttpPost("register")]
        public async Task<ReturnModel> Register([FromBody] UserCreateModel userCreateModel)
        {
            var newUserr = _mapper.Map<User>(userCreateModel);
            var newUser = await _userServices.AddAsync(newUserr);
            return new ReturnModel
            {
                Success = true,
                Message = "User Created successfully",
                Data = newUser,
                StatusCode = 201
            };
        }
    }
}
