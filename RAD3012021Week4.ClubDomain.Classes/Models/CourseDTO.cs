using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAD3012021Week4.ClubDomain.Classes.Models
{
    //this is an intermediate object, teh data is loaded in here first which accepts 3 strings which transfers all the data into The Course object
    public class CourseDTO
    {
        public string CourseCode { get; set; }
        public string Year { get; set; }
        public string Title { get; set; }
    }
}
