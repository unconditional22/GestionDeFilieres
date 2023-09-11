using System;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentManagement.Models
{
    public class Enrollment
    {
        public Enrollment()
        {
            EnrollmentDate = DateTime.Now;
            // StatusE = "";
        }

        public int Id { get; set; }
        
        [Required(ErrorMessage = "StudentId is required.")]
        public int StudentId { get; set; }
        
        [Required(ErrorMessage = "CourseId is required.")]
        public int CourseId { get; set; }

        [Display(Name = "Enrollment Date")]
        [Required(ErrorMessage = "Enrollment Date is required.")]
        public DateTime EnrollmentDate { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string StatusE { get; set; } // Example: "Active", "Complete", "Pending", "Dropped"
    }
}
