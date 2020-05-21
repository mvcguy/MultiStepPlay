using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyPersonalDiary.com.Domain.Services
{
    public interface IDiaryService
    {
        Task<IEnumerable<DiaryNoteVo>> GetAllNotes(DateTime? from, DateTime? to);

        Task<DiaryNoteVo> GetNoteById(Guid? id);

        Task AddNote(DiaryNoteVo noteVo);

        Task UpdateNote(DiaryNoteVo noteVo);

        Task DeleteNote(DiaryNoteVo noteVo);
    }
}
