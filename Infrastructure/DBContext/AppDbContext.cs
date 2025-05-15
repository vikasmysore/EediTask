using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Student> Students => Set<Student>();
        public DbSet<Topic> Topics => Set<Topic>();
        public DbSet<SubTopic> SubTopics => Set<SubTopic>();
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<Answer> Answers => Set<Answer>();
    }
}
