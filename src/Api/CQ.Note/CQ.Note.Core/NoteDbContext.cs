using Microsoft.EntityFrameworkCore;

namespace CQ.Note.Core
{
    public class NoteDbContext : DbContext
    {
        public NoteDbContext(DbContextOptions<NoteDbContext> options)
            : base(options)
        { }

        public DbSet<Models.Note> Notes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Note>()
                .HasKey(n => n.Id);

            modelBuilder.Entity<Models.Note>()
                .Property(n => n.Title)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Models.Note>()
                .Property(n => n.Description)
                .HasMaxLength(200);

            modelBuilder.Entity<Models.Note>()
                 .HasMany(n => n.NoteContents)
                 .WithOne(c => c.Note)
                 .HasForeignKey(c => c.NoteId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
