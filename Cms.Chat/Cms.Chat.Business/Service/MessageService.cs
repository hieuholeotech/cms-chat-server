using Cms.Chat.Dtos;
using Cms.Chat.Infrastructures.IServices;
using Cms.Model.Context;
using Cms.Model.Entities;
using Cms.Model.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cms.Chat.Business.Service
{
    public class MessageService : IMessageService
    {
        private readonly DataDbContext _context;

        public MessageService(DataDbContext context)
        {
            _context = context;
        }

        public async Task<List<Message>> GetMessagesAsync()
        {
            var messages = await _context.Messages.ToListAsync<Message>();

            return messages;
        }

        public async Task<List<Message>> GetMessagesForChatRoomAsync(Guid roomId)
        {
            var messagesForRoom = await _context.Messages
                                      .Where(m => m.RoomId == roomId)
                                               .ToListAsync<Message>();

            return messagesForRoom;
        }

        public async Task<bool> AddMessageToRoomAsync(Guid roomId, CreateMessageDto messageDto)
        {
            Message message = new Message()
            {
                Id = new Guid(),
                RoomId = messageDto.RoomId,
                MessageContent = messageDto.MessageContent,
                AppUserId = messageDto.AppUserId,
                CreatedTime = DateTime.Now,
                CreatedDate = DateTime.Now,
                Status = Status.Active
        };

            _context.Messages.Add(message);

            var saveResults = await _context.SaveChangesAsync();

            return saveResults > 0;
        }
    }
}
