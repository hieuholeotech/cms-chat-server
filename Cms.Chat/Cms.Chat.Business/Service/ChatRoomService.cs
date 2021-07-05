using Cms.Chat.Dtos;
using Cms.Chat.Infrastructures.IServices;
using Cms.Model.Context;
using Cms.Model.Entities;
using Cms.Model.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cms.Chat.Business.Service
{
    public class ChatRoomService : IChatRoomService
    {
        private readonly DataDbContext _context;

        public ChatRoomService(DataDbContext context) 
        {
            _context = context;
        }

        public async Task<List<Room>> GetChatRoomsAsync()
        {
            var chatRooms = await _context.Rooms.ToListAsync<Room>();

            return chatRooms;
        }

        public async Task<bool> AddChatRoomAsync(CreateRoomDto chatRoom)
        {
            Room room = new Room()
            {
                Id = new Guid(),
                Name = chatRoom.Name,
                Type = chatRoom.Type,
                CreatedDate = DateTime.Now,
                CreatedTime = DateTime.Now,
                Status =  Status.Active

            };

            _context.Rooms.Add(room);

            var saveResults = await _context.SaveChangesAsync();

            return saveResults > 0;
        }
    }
}