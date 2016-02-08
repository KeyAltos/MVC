using System.Data.Entity;
using System.Diagnostics;

namespace ORM
{
    public partial class EntityModel : DbContext
    {
        public EntityModel()
            : base("name=EntityModel")
        {
            
        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Friendship> Friendships { get; set; }

        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Message> Messages { get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasKey(x => x.Id)
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>().HasKey(x => x.Id)
                .HasMany(e => e.Friendships)
                .WithRequired(e => e.FriendOne)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Friendships)
                .WithRequired(e => e.FriendTwo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.Receiver).HasForeignKey(x => x.ReceiverId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.Sender).HasForeignKey(x => x.SenderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
               .HasMany(e => e.Grades)
               .WithRequired(e => e.Appreiser)
               .WillCascadeOnDelete(false);

            modelBuilder.Entity<Author>().HasKey(x => x.Id)
                .HasMany(e => e.Books)
                .WithRequired(e => e.Author)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>().HasKey(x => x.Id)
               .HasMany(e => e.Genres)
               .WithMany(e => e.Books);

            modelBuilder.Entity<Book>()
               .HasMany(e => e.Grades)
               .WithRequired(e => e.Book)
               .WillCascadeOnDelete(false);
        }

        new public void Dispose()
        {
            base.Dispose();            
        }
    }
}
