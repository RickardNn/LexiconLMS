using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lexicon_LMS.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }

     
        public int CourseId { get; set; }

        [DisplayName("Typ")]
        public string Type { get; set; }

        [DisplayName("Aktivitet")]
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

        public virtual Course Course { get; set; }
    }
}