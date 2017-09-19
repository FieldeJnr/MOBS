using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobs.Data
{
    public class UserCategory
    {
        public UserCategory() {

            Whiteboards = new HashSet<Whiteboard>();
        }

        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Whiteboard> Whiteboards { get; private set; }
    }
}
