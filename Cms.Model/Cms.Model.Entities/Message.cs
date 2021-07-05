using Cms.Model.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Model.Entities
{
    public class Message
    {
        [Column("id")]
        public Guid Id { set; get; }
        [Column("room_id")]
        public Guid RoomId { set; get; }
        [Column("app_user_id")]
        public Guid AppUserId { set; get; }
        [Column("message_content")]
        public string MessageContent { set; get; }
        [Column("in_user_id")]
        public Guid CreatedBy { set; get; }
        [Column("up_user_id")]
        public Guid UpdatedBy { set; get; }
        [Column("in_ymd")]
        public DateTime CreatedDate { set; get; }
        [Column("up_ymd")]
        public DateTime UpdatedDate { set; get; }
        [Column("in_time")]
        public DateTime CreatedTime { set; get; }
        [Column("up_time")]
        public DateTime UpdatedTime { set; get; }
        [Column("del_flg")]
        public DateTime DeleteFlag { set; get; }
        [Column("status")]
        public Status Status { set; get; }

        [Column("app_user")]
        public virtual AppUser AppUser { set; get; }
        [Column("room")]
        public virtual Room Room { set; get; }
    }
}
