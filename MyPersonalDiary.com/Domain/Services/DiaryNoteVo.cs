using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyPersonalDiary.com.Domain.Services
{
    public class DiaryNoteVo
    {
        public Guid? Id { get; set; }
                
        [StringLength(1000, MinimumLength = 3)]
        [DisplayName("Title")]
        public string Title { get; set; }

        [StringLength(2500)]
        [DisplayName("Summary")]
        public string Summary { get; set; }
                
        [StringLength(int.MaxValue, MinimumLength = 3)]
        [DisplayName("Details")]
        public string Details { get; set; }

        [DisplayName("Created on")]
        public DateTime? CreatedOn { get; set; }

        [DisplayName("Edited On")]
        public DateTime? ModifiedOn { get; set; }

        [DisplayName("Author")]
        public string CreatedBy { get; set; }

        [DisplayName("Edited by")]
        public string ModifiedBy { get; set; }

        public bool IsDraft { get; set; }
    }
}
