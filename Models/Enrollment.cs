namespace EnrollmentManagement.Models
{
    public class Enrollment
    {
        public Enrollment() // Initialisation des Proprietes dans le Constructor
    {
        EnrollmentDate = DateTime.Now;
        //StatusE = "";
    }
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string? StatusE { get; set; } // Example: "Active", "Complete", "Pending", "Dropped"
    }
}
