using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Data.Entities
{
    public class User:BaseEntity
    {
        [StringLength(50)]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [StringLength(100)]
        public string FullName { get; set; }
        public string? Avater { get; set; }
        public string? Role { get; set; }
        public string? ConnectionId { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
