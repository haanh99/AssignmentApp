namespace AssignmentApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ICollection<CourseEnrollment> Enrollments { get; set; }
    }
}
