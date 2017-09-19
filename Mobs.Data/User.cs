namespace Mobs.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Whiteboards = new HashSet<Whiteboard>();
            UserCategories = new HashSet<UserCategory>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Whiteboard> Whiteboards { get; set; }
        public virtual ICollection<UserCategory> UserCategories { get; private set; }
    }
}
