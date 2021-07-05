using Cms.Chat.Dtos;
using Cms.Chat.Infrastructures.IServices;
using Cms.Model.Entities;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Cms.Chat.Business.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatRoomService _chatRoomService;
        private readonly IMessageService _messageService;
        public int UsersOnline;

        public ChatHub(IChatRoomService chatRoomService, IMessageService messageService)
        {
            _chatRoomService = chatRoomService;
            _messageService = messageService;
        }

        //public async Task SendMessage(CreateMessageDto messageDto)
        //{
        //    Message m = new Message()
        //    {
        //        RoomId = messageDto.RoomId,
        //        MessageContent = messageDto.MessageContent,
        //        AppUserId = messageDto.AppUserId
        //    };

        //    await _messageService.AddMessageToRoomAsync(messageDto.RoomId, messageDto);
        //    await Clients.All.SendAsync("ReceiveMessage", messageDto);
        //}

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task AddChatRoom(CreateRoomDto chatRoom)
        {
            await _chatRoomService.AddChatRoomAsync(chatRoom);
            await Clients.All.SendAsync("NewRoom", chatRoom.Name);
        }

        public override async Task OnConnectedAsync()
        {
            UsersOnline++;
            await Groups.AddToGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            UsersOnline--;
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");
            await base.OnDisconnectedAsync(exception);
        }
    }
}