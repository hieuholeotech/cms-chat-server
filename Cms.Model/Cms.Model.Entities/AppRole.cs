using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cms.Model.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        [Column("description")]
        public string Description { get; set; }
    }
}
