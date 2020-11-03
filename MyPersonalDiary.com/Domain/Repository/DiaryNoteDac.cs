using System.ComponentModel.DataAnnotations.Schema;

namespace MyPersonalDiary.com.Domain.Repository
{
    [Table("DiaryNote")]
    public class DiaryNoteDac : AuditFields
    {       
        public string NoteTitle { get; set; }

        public string Summary { get; set; }

        public string Details { get; set; }

        public bool? IsDraft { get; set; }
    }
}
