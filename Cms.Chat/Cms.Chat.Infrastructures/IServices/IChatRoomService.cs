using Cms.Chat.Dtos;
using Cms.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cms.Chat.Infrastructures.IServices
{
    public interface IChatRoomService
    {
        Task<List<Room>> GetChatRoomsAsync();
        Task<bool> AddChatRoomAsync(CreateRoomDto newChatRoom);
    }
}
