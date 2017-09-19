using Mobs.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobs.Models.User
{
    public enum ItemTypeEnum
    {
        Text = 1,
        StickyNote,
        Video,
        Image,
        Draw,
        Link,

    }
    public class ItemTypeModel
    {
        public ItemTypeEnum Id { get; set; }

        [Required]
        [StringLength(50)]
        public int Name { get; set; }

        public virtual ICollection<WhiteboardItem> WhitebaordItems { get; set; }
    }
}
