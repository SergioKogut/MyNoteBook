using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyNoteBook.DataBase
{
    [Table("tblNoteBook")]
    public class NoteBook
    {
        [Key]
        public int NoteBookId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<NoteMessage> NoteMessages { get; set; }

       
    }
}