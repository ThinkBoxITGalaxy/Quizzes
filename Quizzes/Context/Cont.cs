using Microsoft.EntityFrameworkCore;
using Quizzes.Models;

namespace Quizzes.Context
{
    public class Cont : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Studies>(
                    builder =>
                    {
                        builder.HasNoKey();
                    });
            modelBuilder
                .Entity<SubjectView>(
                    builder => {
                        builder.HasNoKey();
                    });
        }

        public Cont(DbContextOptions<Cont> contextOptions) : base(contextOptions) { }
        public DbSet<TeachersModel> teachers { get; set; }
        public DbSet<Studies> studies { get; set; }
        public DbSet<SubjectView> subjectViews { get; set; }
    }
}
