using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Chat.Dtos
{
    public class CreateMessageDto
    {
        public Guid RoomId { set; get; }
        public Guid AppUserId { set; get; }
        public string MessageContent { set; get; }
    }
}
