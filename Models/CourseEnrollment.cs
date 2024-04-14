using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace AssignmentApp.Models
{
    public class CourseEnrollment
    {
        
        public int ID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }

        public Courses Course { get; set; }
        public StudentEntity Student { get; set; }


    }
}
