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
            //Initialize DbSet properties using AddRange

            //Initialize Courses using AddRange
            if (Courses != null)
            {
                Courses.AddRange(new Course[]
                {
                    new Course { Title = "Genie Logiciel", Description = "Developement & Technologie Web", StatusC = "Ouvert" },
                    new Course { Title = "Business", Description = "Marketing Digital", StatusC = "Fermer" }
                });
            }

            // Initialize Students using AddRange
            if (Students != null)
            {
                Students.AddRange(new Student[]
                {
                    new Student { FirstName = "John", LastName = "Doe" },
                    new Student { FirstName = "Jane", LastName = "Smith" }
                });
            }

            // Initialize Enrollments using AddRange
            // if (Enrollments != null)
            // {
            //     Enrollments.AddRange(new Enrollment[]
            //     {
            //         new Enrollment { StudentId = 1, CourseId = 1, EnrollmentDate = new DateTime(2023, 08, 12) },
            //         new Enrollment { StudentId = 2, CourseId = 2, EnrollmentDate = new DateTime(2023, 08, 12) }
            //     });
            // }

        }

        // Add DbSet properties for your models
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Enrollment>? Enrollments { get; set; }
    }
}
