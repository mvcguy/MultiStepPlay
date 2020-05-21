using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyPersonalDiary.com.Domain.Repository
{
    public interface INotesRepository
    {
        Task AddDiaryNote(DiaryNoteDac note);

        void UpdateDiaryNote(DiaryNoteDac note);

        Task<IEnumerable<DiaryNoteDac>> GetDiaryNotes(DateTime? from, DateTime? to);

        Task<DiaryNoteDac> GetDiaryNoteById(Guid? id);

        void DeleteNote(DiaryNoteDac note);

        Task<int> SaveChanges();
    }
}
