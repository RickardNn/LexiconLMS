using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lexicon_LMS.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        public string ApplicationUserId { get; set; }
        public int? GroupId { get; set; }
        public int? CourseId { get; set; }
        public int? ActivityId { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual Group Group { get; set; }
        public virtual Course Course { get; set; }
        public virtual Activity Activity { get; set; }
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}