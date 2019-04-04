using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyNoteBook.DataBase
{
    [Table("tblNoteMessages")]
    public class NoteMessage
    {
        [Key]
        public int NoteMessageId { get; set; }

        public string Message { get; set; }

        public string Title { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual NoteBook NoteBook { get; set; }
    }
}