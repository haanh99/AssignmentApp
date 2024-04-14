using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AssignmentApp.Models;
using System.Diagnostics;
namespace AssignmentApp.Data
{
    public static class DbSeedcs
    {
        public static void DataSeed(DbContext context)
        {
          
            var students = new StudentEntity[]
           {
                new StudentEntity { Name = "ses",   Age = 22, Majo ="It" },
                new StudentEntity { Name = "alisd",   Age = 22, Majo ="Marketing" },
                new StudentEntity { Name = "noas",   Age = 22, Majo ="Design" },
                new StudentEntity { Name = "lewo",   Age = 22, Majo ="Design" },
                new StudentEntity { Name = "daes",   Age = 22, Majo ="It" },
                new StudentEntity { Name = "sfa",   Age = 22, Majo ="Marketing" },
           };
            foreach (StudentEntity s in students)
            {
                context.Add(s);
            }
            context.SaveChanges();

            var courses = new Courses[]
            {
                new Courses {Name = "ITCourse01", StartTime = new DateTime(2022, 1, 10, 9, 0, 0),
                EndTime = new DateTime(2022, 1, 10, 11, 0, 0)
                },
                new Courses {Name = "ITCourse02",
                StartTime = new DateTime(2022, 1, 11, 14, 0, 0),
                EndTime = new DateTime(2022, 1, 11, 16, 0, 0)
                },
                new Courses {Name = "MKCourse01",
                StartTime = new DateTime(2022, 1, 11, 14, 0, 0),
                EndTime = new DateTime(2022, 1, 11, 16, 0, 0)
                },
                new Courses {Name = "DSCourse01",
                StartTime = new DateTime(2022, 1, 11, 14, 0, 0),
                EndTime = new DateTime(2022, 1, 11, 16, 0, 0)
                },


            };

            foreach (Courses c in courses)
            {
                context.Add(c);
            }
            context.SaveChanges();

            //var enrollments = new CourseEnrollment[]
            //{
            //    new CourseEnrollment {
            //        StudentID = students.Single(s => s.Name== "ses").Id,
            //        CourseID = courses.Single(c => c.Name == "ITCourse01" ).Id,
                    
            //    },
            //    new CourseEnrollment {
            //        StudentID = students.Single(s => s.Name== "alisd").Id,
            //        CourseID = courses.Single(c => c.Name == "MKCourse01" ).Id,

            //    },
            //    new CourseEnrollment {
            //        StudentID = students.Single(s => s.Name== "noas").Id,
            //        CourseID = courses.Single(c => c.Name == "DSCourse01" ).Id,

            //    },
            //    new CourseEnrollment {
            //        StudentID = students.Single(s => s.Name== "lewo").Id,
            //        CourseID = courses.Single(c => c.Name == "DSCourse01" ).Id,

            //    },
            //    new CourseEnrollment {
            //        StudentID = students.Single(s => s.Name== "daes").Id,
            //        CourseID = courses.Single(c => c.Name == "ITCourse01" ).Id,

            //    },
            //    new CourseEnrollment {
            //        StudentID = students.Single(s => s.Name== "daes").Id,
            //        CourseID = courses.Single(c => c.Name == "ITCourse02" ).Id, 
            //    }

            //};
            //foreach (CourseEnrollment enrollment in enrollments)
            //{
            //    context.Add(enrollment);
            //}
            //context.SaveChanges();
        }
    }
}
