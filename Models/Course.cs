namespace CourseManagement.Models
{
    public class Course
    {
        public Course() // Initialisation des Proprietes dans le Constructor
    {
        // Title = "";
        // Description = "";
        // StatusC = "";
    }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? StatusC { get; set; } // Example: "Open", "Closed", "Canceled"
    }
}
