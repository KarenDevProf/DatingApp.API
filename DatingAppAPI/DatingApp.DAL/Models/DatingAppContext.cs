using Microsoft.EntityFrameworkCore;

namespace DatingApp.DAL.Models
{
    public partial class DatingAppContext : DbContext
    {
        public DatingAppContext()
        {
        }


        public DatingAppContext(DbContextOptions<DatingAppContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<UserDish> UserDishes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=DatingApp;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDish>()
                .HasKey(ud => new { ud.UserId, ud.DishId });

            modelBuilder.Entity<UserDish>()
                .HasOne(ud => ud.User)
                .WithMany(u => u.UserDishes)
                .HasForeignKey(ud => ud.UserId);

            modelBuilder.Entity<UserDish>()
                .HasOne(ud => ud.Dish)
                .WithMany(d => d.UserDishes)
                .HasForeignKey(ud => ud.DishId);

            modelBuilder.Entity<Like>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.User)
                .WithMany(u => u.Likes)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Like>()
                .HasOne(l => l.Dish)
                .WithMany(d => d.Likes)
                .HasForeignKey(l => l.DishId)
                .OnDelete(DeleteBehavior.Restrict);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
