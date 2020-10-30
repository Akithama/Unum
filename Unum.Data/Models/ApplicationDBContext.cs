using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Unum.Data.Modelss;

namespace Unum.Data.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Answers> Answers { get; set; }
        public DbSet<QuestionAnswerMapping> QuestionAnswerMapping { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Survey> Survey { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserResponse> UserResponse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }       
    }
}
