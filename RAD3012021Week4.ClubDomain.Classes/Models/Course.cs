using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RAD3012021Week4.ClubDomain.Classes.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseID { get; set; }
        public string CourseCode { get; set; }
        public int Year { get; set; }
        public string CourseName { get; set; }
        public virtual ICollection<Student> CourseStudents { get; set; }
    }
}
