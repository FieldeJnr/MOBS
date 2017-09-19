using Mobs.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobs.Models.User
{
    public class WhitebaordItemModel
    {

        public int Id { get; set; }
        public int WhiteboardId { get; set; }


        public string Text { get; set; }

        //Need to determin which are required fields

        public int X { get; set; }
        public int Y { get; set; }
        public int? Width { get; set; }
        public int? Depth { get; set; }
        public Byte[] Image { get; set; }
        public int? FontSize { get; set; }
        [Required]
        public string Colour { get; set; }

        public ItemTypeEnum ItemTypeId { get; set; }
        public string ItemTypeName { get; set; }
    }
}
