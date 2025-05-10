
using IDSmarter.Domain.Entities;
using Microsoft.EntityFrameworkCore;



namespace IDSmarter.Infrastructure.Data
{
    public class IDSmarterDbContext : DbContext
    {
        public IDSmarterDbContext(DbContextOptions<IDSmarterDbContext> options) : base(options)
        {
        }

        // DbSets for all entities
        public DbSet<Admins> Admin { get; set; }
        public DbSet<Courses> Course { get; set; }
        public DbSet<Deans> Dean { get; set; }
        public DbSet<DepPrograms> DepProgram { get; set; }
        public DbSet<Enrollments> Enrollment { get; set; }
        public DbSet<Grades> Grade { get; set; }
        public DbSet<InstructorDetails> InstructorDetail { get; set; }
        public DbSet<Instructors> Instructor { get; set; }
        public DbSet<PreRegistrations> PreRegistration { get; set; }
        public DbSet<Schedules> Schedule { get; set; }
        public DbSet<Strands> Strand { get; set; }
        public DbSet<StudentDetails> StudentDetail { get; set; }
        public DbSet<Students> Student { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<Admission> Admissions { get; set; }
        public DbSet<StudentService> StudentServices { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Admins>()
                .HasMany(a => a.Student)
                .WithOne(s => s.Admin)
                .HasForeignKey(s => s.AdminId);

            modelBuilder.Entity<Admins>()
                .HasMany(a => a.Instructor)
                .WithOne(i => i.Admin)
                .HasForeignKey(i => i.AdminId);

            modelBuilder.Entity<Admins>()
                .HasMany(a => a.Dean)
                .WithOne(d => d.Admin)
                .HasForeignKey(d => d.AdminId);


            modelBuilder.Entity<Courses>()
                .HasOne(c => c.Instructor)
                .WithMany(i => i.Course)
                .HasForeignKey(c => c.Id)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Courses>()
                .HasMany(c => c.Enrollment)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId);


            modelBuilder.Entity<Deans>()
                .HasMany(d => d.Student)
                .WithOne(s => s.Dean)
                .HasForeignKey(s => s.DeanId);

            modelBuilder.Entity<Deans>()
                .HasMany(d => d.Instructor)
                .WithOne(i => i.Dean)
                .HasForeignKey(i => i.DeanId);



            modelBuilder.Entity<DepPrograms>()
                .HasMany(dp => dp.Student)
                .WithOne(s => s.DepProgram)
                .HasForeignKey(s => s.DepProgramId);

            modelBuilder.Entity<DepPrograms>()
                .HasMany(dp => dp.PreRegistration)
                .WithOne(pr => pr.DepProgram)
                .HasForeignKey(pr => pr.DepProgramId);



            modelBuilder.Entity<Enrollments>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollment)
                .HasForeignKey(e => e.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Enrollments>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollment)
                .HasForeignKey(e => e.Id)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Enrollments>()
                .HasOne(e => e.PreRegistration)
                .WithMany(pr => pr.Enrollment)
                .HasForeignKey(e => e.Id)
                .OnDelete(DeleteBehavior.SetNull);



            modelBuilder.Entity<Grades>()
                .HasOne(g => g.Student)
                .WithMany(s => s.Grade)
                .HasForeignKey(g => g.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Grades>()
                .HasOne(g => g.Course)
                .WithMany(c => c.Grade)
                .HasForeignKey(g => g.CourseId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Grades>()
                .HasOne(g => g.Strand)
                .WithMany(s => s.Grade)
                .HasForeignKey(g => g.StrandId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Grades>()
                .HasOne(g => g.DepProgram)
                .WithMany(p => p.Grade)
                .HasForeignKey(g => g.ProgramId)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<InstructorDetails>()
                .HasOne(id => id.Program)
                .WithMany(p => p.InstructorDetail)
                .HasForeignKey(id => id.ProgramId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<InstructorDetails>()
                .HasOne(id => id.Strand)
                .WithMany(s => s.InstructorDetail)
                .HasForeignKey(id => id.StrandId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<InstructorDetails>()
                .HasOne(id => id.Schedule)
                .WithMany(s => s.InstructorDetail)
                .HasForeignKey(id => id.ScheduleId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<InstructorDetails>()
                .HasOne(id => id.PreRegistration)
                .WithMany(pr => pr.InstructorDetail)
                .HasForeignKey(id => id.PreRegistrationId)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<Instructors>()
                .HasMany(i => i.Course)
                .WithOne(c => c.Instructor)
                .HasForeignKey(c => c.InstructorId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Instructors>()
                .HasOne(i => i.InstructorDetail)
                .WithMany(id => id.Instructor)
                .HasForeignKey(i => i.InstructorDetailId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<PreRegistrations>()
                .HasMany(pr => pr.Student)
                .WithOne(s => s.PreRegistration)
                .HasForeignKey(s => s.PreRegistrationId);

            modelBuilder.Entity<PreRegistrations>()
                .HasMany(pr => pr.Enrollment)
                .WithOne(e => e.PreRegistration)
                .HasForeignKey(e => e.PreRegistrationId);

            modelBuilder.Entity<Schedules>()
                .HasMany(s => s.InstructorDetail)
                .WithOne(id => id.Schedule)
                .HasForeignKey(id => id.ScheduleId)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<Strands>()
                .HasMany(s => s.Grade)
                .WithOne(g => g.Strand)
                .HasForeignKey(g => g.StrandId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Strands>()
                .HasMany(s => s.PreRegistration)
                .WithOne(pr => pr.Strand)
                .HasForeignKey(pr => pr.StrandId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Strands>()
                .HasMany(s => s.InstructorDetail)
                .WithOne(id => id.Strand)
                .HasForeignKey(id => id.StrandId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Students>()
                .HasMany(s => s.Enrollment)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Students>()
                .HasMany(s => s.Grade)
                .WithOne(g => g.Student)
                .HasForeignKey(g => g.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Students>()
                .HasOne(s => s.StudentDetail)
                .WithOne(sd => sd.Student)
                .HasForeignKey<StudentDetails>(sd => sd.StudentId);


        }
    }
}

