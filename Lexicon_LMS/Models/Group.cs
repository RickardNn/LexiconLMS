using Foolproof;
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

        [Required]
        [DisplayName("Gruppnamn")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Lärare")]
        public string Teacher { get; set; }

        [DisplayName("Beskrivning")]
        public string Description { get; set; }

        [Required]
        [DisplayName("Startdatum")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Slutdatum kan ej vara tidigare än startdatum.")]
        //[GreaterThan("StartDate")]
        [DisplayName("Slutdatum")]
        [DataType(DataType.Date)]
        [GreaterThanOrEqualTo("StartDate")]
        public DateTime EndDate { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

    }
}