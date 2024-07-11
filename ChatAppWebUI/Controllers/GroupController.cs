using AutoMapper;
using ChatApp.Data.Entities;
using ChatApp.Data.Models;
using ChatApp.Services.Models.Group;
using ChatApp.Services.Services.Groups;
using ChatAppWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatAppWebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GroupController : Controller
    {
        private readonly IGroupSerivces _groupSerivces;
        private readonly IMapper _mapper;
        public GroupController(IGroupSerivces groupSerivces, IMapper mapper)
        {
            _groupSerivces = groupSerivces;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ReturnModel> Get([FromQuery] PaginationModel paginationModel)
        {
            var groups = await _groupSerivces.ListAllAsync(paginationModel);
            return new ReturnModel
            {
                Success = true,
                Message = "Success",
                Data = _mapper.Map<List<GroupModel>>(groups),
                StatusCode = 200,
                TotalCount = await _groupSerivces.CountAsync()
            };
        }
        [HttpGet("{id}")]
        public async Task<ReturnModel> Get(int id)
        {
            var group=await _groupSerivces.GetByIdAsync(id);
            return new ReturnModel
            {
                Success = true,
                Message = "Success",
                Data = _mapper.Map<GroupModel>(group),
                StatusCode = 200
            };
        }
        [HttpPost]
        public async Task<ReturnModel> Post([FromBody] GroupCreateModel groupModel)
        {
            var group = _mapper.Map<Group>(groupModel);
            var groupResult= await _groupSerivces.AddAsync(group);
            return new ReturnModel
            {
                Success = true,
                Message = "Success",
                Data = _mapper.Map<GroupModel>(groupResult),
                StatusCode = 200
            };
        }
        [HttpPut]
        public async Task<ReturnModel> Put([FromBody] GroupUpdateModel groupModel)
        {
            var group = _mapper.Map<Group>(groupModel);
            var groupResult = await _groupSerivces.UpdateAsync(group);
            return new ReturnModel
            {
                Success = true,
                Message = "Success",
                Data = _mapper.Map<GroupModel>(groupResult),
                StatusCode = 200
            };
        }
        [HttpDelete("{id}")]
        public async Task<ReturnModel> Delete(int id)
        {
            var group =await _groupSerivces.GetByIdAsync(id);
            await _groupSerivces.DeleteAsync(group);
            return new ReturnModel
            {
                Success = true,
                Message = "Success",
                StatusCode = 200
            };
        }

    }
}
