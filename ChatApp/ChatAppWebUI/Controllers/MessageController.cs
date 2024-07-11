using AutoMapper;
using ChatApp.Data.Entities;
using ChatApp.Data.Models;
using ChatApp.Services.Models.Message;
using ChatApp.Services.Services.Messages;
using ChatAppWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatAppWebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IMessageServices _messageServices;
        private readonly IMapper _mapper;
        public MessageController(IMessageServices messageServices, IMapper mapper)
        {
            _messageServices = messageServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ReturnModel> Get([FromQuery] PaginationModel paginationModel)
        {
            var message = await _messageServices.ListAllAsync(paginationModel);
            return new ReturnModel
            {
                Success = true,
                Message = "Success",
                Data = _mapper.Map<List<MessageModel>>(message),
                StatusCode = 200,
                TotalCount = await _messageServices.CountAsync()
            };
        }
        [HttpGet("{id}")]
        public async Task<ReturnModel> Get(int id)
        {
            var message = await _messageServices.GetByIdAsync(id);
            return new ReturnModel
            {
                Success = true,
                Message = "Success",
                Data = _mapper.Map<MessageModel>(message),
                StatusCode = 200,

            };
        }
        [HttpPost]
        public async Task<ReturnModel> Post([FromBody] MessageCreateModel messageModel)
        {
            var message = _mapper.Map<Message>(messageModel);
            var messageResult = await _messageServices.AddAsync(message);
            return new ReturnModel
            {
                Success = true,
                Message = "Success",
                Data = _mapper.Map<MessageModel>(messageResult),
                StatusCode = 200
            };
        }
        [HttpPut]
        public async Task<ReturnModel> Put([FromBody] MessageUpdateModel messageModel)
        {
            var message = _mapper.Map<Message>(messageModel);
            var messageResult = await _messageServices.UpdateAsync(message);
            return new ReturnModel
            {
                Success = true,
                Message="Success",
                Data=_mapper.Map<MessageModel>(messageResult),
                StatusCode = 200
            };
        }
        [HttpDelete("{id}")]
        public async Task<ReturnModel>Delete(int id)
        {
            var message= await _messageServices.GetByIdAsync(id);
            await _messageServices.DeleteAsync(message);
            return new ReturnModel
            {
                Success = true,
                Message = "Success",
                StatusCode = 200
            };
        }
    }
}
