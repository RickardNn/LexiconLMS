using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lexicon_LMS.Models
{
    public class Group
    {
        public int GroupId { get; set; }

        public string TeacherId { get; set; }

        [Required]
        [DisplayName("Gruppnamn")]
        public string Name { get; set; }

        //[Required]
        //[DisplayName("Lärare")]
        //public string Teacher { get; set; }

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
        [GreaterThanOrEqualTo("StartDate", ErrorMessage = "Slutdatum kan ej vara tidigare än startdatum.")]
        public DateTime EndDate { get; set; }

        //[ForeignKey("TeacherId")]
        //public virtual ApplicationUser Teacher { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

    }
}