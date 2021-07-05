using Cms.Chat.Dtos;
using Cms.Chat.Infrastructures.IServices;
using Cms.Model.Entities;
using Cms.Model.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cms.WebApplication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize("Bearer")]
    public class ChatRoomController : Controller
    {
        private readonly IChatRoomService _chatRoomService;

        public ChatRoomController(IChatRoomService chatRoomService)
        {
            _chatRoomService = chatRoomService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var chatRooms = await _chatRoomService.GetChatRoomsAsync();

            return Ok(chatRooms);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateRoomDto chatRoom)
        {
            var result = await _chatRoomService.AddChatRoomAsync(chatRoom);
            return Ok(result);
        }
    }
}