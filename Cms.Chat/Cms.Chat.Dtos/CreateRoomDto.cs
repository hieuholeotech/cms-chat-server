using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Chat.Dtos
{
    public class CreateRoomDto
    {
        public string Name { set; get; }
        public int Type { set; get; }
    }
}
