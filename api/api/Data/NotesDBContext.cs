using api.Data.Map;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class NotesDBContext : DbContext
    {
        public NotesDBContext(DbContextOptions<NotesDBContext> options) : base(options) {
            
        }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<NoteModel> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new NoteMap());
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.Entity<NoteModel>()
                .HasOne(n => n.User)  
                .WithMany(u => u.Notes) 
                .HasForeignKey(n => n.UserId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }
    }
}
