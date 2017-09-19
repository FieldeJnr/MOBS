namespace Mobs.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dbMobs : DbContext
    {
        public dbMobs()
            : base("name=dbMobs")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Whiteboard> Whiteboards { get; set; }
        public virtual DbSet<WhiteboardItem> WhiteboardItems { get; set; }
        public virtual DbSet<UserCategory> UserCategories { get; set; }
        public virtual DbSet<ItemType> ItemTypes { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Whiteboards)
                .WithRequired(e => e.User)
                .HasForeignKey(e=>e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Whiteboard>()
            .HasMany(e => e.WhiteboardItems)
            .WithRequired(e => e.Whiteboard)
            .HasForeignKey(e => e.WhiteboardId)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<Whiteboard>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
          .HasMany(e => e.UserCategories)
          .WithRequired(e => e.User)
          .HasForeignKey(e => e.UserId)
          .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserCategory>()
        .HasMany(e => e.Whiteboards)
        .WithRequired(e => e.UserCategory)
        .HasForeignKey(e => e.UserCategoryId)
        .WillCascadeOnDelete(false);

            modelBuilder.Entity<ItemType>()
       .HasMany(e => e.WhitebaordItems)
       .WithRequired(e => e.ItemType)
       .HasForeignKey(e => e.ItemTypeId)
       .WillCascadeOnDelete(false);
        }
    }
}
