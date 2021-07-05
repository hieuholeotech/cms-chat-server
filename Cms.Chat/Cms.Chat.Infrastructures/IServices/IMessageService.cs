using Cms.Chat.Dtos;
using Cms.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cms.Chat.Infrastructures.IServices
{
    public interface IMessageService
    {
        Task<List<Message>> GetMessagesAsync();
        Task<List<Message>> GetMessagesForChatRoomAsync(Guid roomId);
        Task<bool> AddMessageToRoomAsync(Guid roomId, CreateMessageDto messageDto);
    }
}
