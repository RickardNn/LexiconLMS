using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Foolproof;

namespace Lexicon_LMS.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public int GroupId { get; set; }
        [Required]
        [DisplayName("Kursnamn")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Lärare")]
        public string Teacher { get; set; }
        [Required]
        [DisplayName("Beskrivning")]
        public string Description { get; set; }
        [Required]
        [DisplayName("Startdatum")]
        [DataType(DataType.Date)]
         public DateTime StartDate { get; set; }
        [Required]
        [DisplayName("Slutdatum")]
        [DataType(DataType.Date)]
        [GreaterThan("StartDate")]
        public DateTime EndDate { get; set; }

        public virtual Group Group { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }


    }
}