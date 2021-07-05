using Cms.Model.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cms.Model.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("full_name")]
        public string FullName { get; set; }
        [Column("date_of_birth")]
        public DateTimeOffset DateOfBirth { get; set; }
        [Column("website")]
        public string Website { get; set; }
        [Column("bio")]
        public string Bio { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("avatar")]
        public string UrlAvatar { get; set; }
        [Column("in_ymd")]
        public DateTime CreatedDate { set; get; }
        [Column("in_time")]
        public DateTime CreatedTime { set; get; }
        [Column("status")]
        public Status Status { set; get; }

        [Column("messages")]
        public ICollection<Message> Messages { get; set; }
    }
}
