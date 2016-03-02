using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lexicon_LMS.Models
{
    public class Group
    {
        public int GroupId { get; set; }

        [DisplayName("Gruppnamn")]
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

        public virtual ICollection<Course> Courses { get; set; }

    }
}