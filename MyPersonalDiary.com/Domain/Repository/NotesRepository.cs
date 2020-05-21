using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPersonalDiary.com.Domain.Repository
{
    public class NotesRepository : INotesRepository
    {
        public NotesRepository(PersonalDiaryDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public PersonalDiaryDbContext DbContext { get; }

        public async Task AddDiaryNote(DiaryNoteDac note)
        {
            await DbContext.AddAsync(note);
        }

        public void DeleteNote(DiaryNoteDac note)
        {
            DbContext.Remove(note);
        }

        public async Task<DiaryNoteDac> GetDiaryNoteById(Guid? id)
        {
            return await DbContext.DiaryNotes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<DiaryNoteDac>> GetDiaryNotes(DateTime? fromx, DateTime? to)
        {
            return await (from note in DbContext.DiaryNotes
                   where (note.CreatedOn >= fromx || fromx == null)
                   && (note.CreatedOn <= to || to == null)
                   select note).ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await DbContext.SaveChangesAsync();
        }

        public void UpdateDiaryNote(DiaryNoteDac note)
        {
            DbContext.Attach(note).State = EntityState.Modified;
        }
    }
}
