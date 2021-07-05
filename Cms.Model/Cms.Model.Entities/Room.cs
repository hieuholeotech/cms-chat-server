using Cms.Model.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Model.Entities
{
    public class Room
    {
        [Column("id")]
        public Guid Id { set; get; }
        [Column("name")]
        public string Name { set; get; }
        [Column("type")]
        public int Type { set; get; }
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
        [Column("messages")]
        public ICollection<Message> Messages { get; set; }

    }
}
