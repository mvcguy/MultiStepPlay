using MyPersonalDiary.com.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonalDiary.com.Domain.Services
{
    public class DiaryService : IDiaryService
    {
        public DiaryService(INotesRepository repository)
        {
            Repository = repository;
        }

        public INotesRepository Repository { get; }

        public async Task AddNote(DiaryNoteVo noteVo)
        {
            var currentUserId = SessionState.GetSession().User.Id;

            var noteDac = noteVo.ToDiaryNoteDac();
            noteDac.CreatedOn = DateTime.UtcNow;
            noteDac.ModifiedOn = DateTime.UtcNow;
            noteDac.CreatedBy = currentUserId;
            noteDac.ModifiedBy = currentUserId;

            await Repository.AddDiaryNote(noteDac);
            await EnsurePersisted();
        }

        private async Task EnsurePersisted()
        {
            var records = await Repository.SaveChanges();
            if (records <= 0)
                throw new Exception("Unknown error occured, changes were not saved.");
        }

        public async Task DeleteNote(DiaryNoteVo noteVo)
        {
            Repository.DeleteNote(noteVo.ToDiaryNoteDac());
            await EnsurePersisted();
        }

        public async Task<IEnumerable<DiaryNoteVo>> GetAllNotes(DateTime? fromx, DateTime? to)
        {
            return from note in await Repository.GetDiaryNotes(fromx, to)
                   select note.ToDiaryNoteVo();
        }

        public async Task<DiaryNoteVo> GetNoteById(Guid? id)
        {
            return (await Repository.GetDiaryNoteById(id)).ToDiaryNoteVo();
        }

        public async Task UpdateNote(DiaryNoteVo noteVo)
        {
            var latest = await Repository.GetDiaryNoteById(noteVo.Id);
            if (latest == null) throw new Exception($"Document with ID: {noteVo.Id} cannot be found");

            if (string.IsNullOrWhiteSpace(noteVo.Title)) throw new Exception("Document title cannot be null/empty");
            if (string.IsNullOrWhiteSpace(noteVo.Details)) throw new Exception("Document body cannot be null/empty");
            var currentUserId = SessionState.GetSession().User.Id;

            latest.NoteTitle = noteVo.Title;
            latest.Details = noteVo.Details;
            latest.Summary = noteVo.Summary;
            latest.ModifiedOn = DateTime.UtcNow;
            latest.ModifiedBy = currentUserId;

            Repository.UpdateDiaryNote(latest);
            await EnsurePersisted();
        }
    }
}
