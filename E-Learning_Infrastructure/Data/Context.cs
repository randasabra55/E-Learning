
using E_Learning_Data.Entities;
using E_Learning_Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace E_Learning_Infrastructure.Data
{
    public class Context : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Courses> courses { get; set; }
        public DbSet<Enrollments> enrollments { get; set; }
        public DbSet<Certificates> certificates { get; set; }
        public DbSet<Lessons> lessons { get; set; }
        public DbSet<Notifications> notifications { get; set; }
        public DbSet<QuizAnswers> quizAnswers { get; set; }
        public DbSet<QuizQuestions> quizQuestions { get; set; }
        public DbSet<Quizzes> quizzes { get; set; }
        public DbSet<Reviews> reviews { get; set; }
        public DbSet<UserQuizzes> userQuizzes { get; set; }
        public DbSet<OTP> OTPs { get; set; }
        public DbSet<UserQuizAttempts> userQuizAttempts { get; set; }
        public DbSet<UserQuizAnswers> userQuizAnswers { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Role>()
                        .HasOne<User>()
                        .WithMany()
                        .HasForeignKey(ur => ur.Id)
                        .OnDelete(DeleteBehavior.Cascade);*/
            modelBuilder.Entity<Role>()
            .Property(r => r.Id)
            .ValueGeneratedOnAdd();
            /*modelBuilder.Entity<Enrollments>()
       .HasOne(e => e.courses)
       .WithMany(c => c.userEnrollments)
       .HasForeignKey(e => e.CourseId)
       .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Courses>()
                .HasOne(c => c.Certificates)
                .WithOne(cert => cert.Courses)
                .HasForeignKey<Certificates>(cert => cert.CourseId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Quizzes>()
                .HasOne(q => q.Courses)
                .WithMany(c => c.quizzes)
                .HasForeignKey(q => q.CourseId)
                .OnDelete(DeleteBehavior.NoAction);*/
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // modelBuilder.UseEncryption(_encryptionProvider);
        }
    }

}
