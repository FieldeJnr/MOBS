using Mobs.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobs.Models.User
{
    public class WhitebaordModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(75)]
        public string Name { get; set; }

        //refactored to usermodel?
        public virtual UserModel User { get; set; }


        public virtual ICollection<WhiteboardItem> WhiteboardItems { get; private set; }

    }
}
