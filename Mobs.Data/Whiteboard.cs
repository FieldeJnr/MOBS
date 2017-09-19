namespace Mobs.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Whiteboard
    {
        public Whiteboard()
        {
            WhiteboardItems = new HashSet<WhiteboardItem>();
        }
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<WhiteboardItem> WhiteboardItems { get; private set; }

        public int UserCategoryId { get; set; }

        public UserCategory UserCategory { get; set; }
    }
}
