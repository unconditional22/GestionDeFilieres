using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CourseManagement.Models; // la classe filere 
using StudentManagement.Models; // la classe etudiant
using EnrollmentManagement.Models; // la classe inscription
using ALoginViewModel.Models.ViewModels; 


namespace CourseManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            // Initialize DbSet properties using AddRange

            // Initialize Courses using AddRange
            // if (Courses != null)
            // {
            //     Courses.AddRange(new Course[]
            //     {
            //         new Course { Title = "Introduction to Programming", Description = "Learn the basics of programming with C#", StatusC = "Open" },
            //         new Course { Title = "Web Development with ASP.NET Core", Description = "Build web applications with ASP.NET Core", StatusC = "Open" }
            //     });
            // }

            // // Initialize Students using AddRange
            // if (Students != null)
            // {
            //     Students.AddRange(new Student[]
            //     {
            //         new Student { FirstName = "", LastName = "" },
            //         new Student { FirstName = "", LastName = "" }
            //     });
            // }

            // Initialize Enrollments using AddRange
            // if (Enrollments != null)
            // {
            //     Enrollments.AddRange(new Enrollment[]
            //     {
            //         new Enrollment { StudentId = 0 , CourseId = 0, EnrollmentDate = 08/02/2023 },
            //         new Enrollment { StudentId = 0 , CourseId = 0, EnrollmentDate = 08/02/2023 }
            //     });
            // }

        }

        // Add DbSet properties for your models
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Enrollment>? Enrollments { get; set; }
    }
}
