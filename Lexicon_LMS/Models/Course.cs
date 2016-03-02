using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Lexicon_LMS.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public int GroupId { get; set; }
        [DisplayName("Kursnamn")]
        public string Name { get; set; }
        [DisplayName("Lärare")]
        public string Teacher { get; set; }
        [DisplayName("Beskrivning")]
        public string Description { get; set; }
        [DisplayName("Startdatum")]
        [DataType(DataType.Date)]
         public DateTime StartDate { get; set; }
        [DisplayName("Slutdatum")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public virtual Group Group { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }


    }
}