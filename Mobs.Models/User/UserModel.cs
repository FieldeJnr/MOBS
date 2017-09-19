using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobs.Models.User
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(75)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

    }
}
