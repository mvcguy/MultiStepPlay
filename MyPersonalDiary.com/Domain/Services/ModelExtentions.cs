using MyPersonalDiary.com.Domain.Repository;

namespace MyPersonalDiary.com.Domain.Services
{
    public static class ModelExtentions
    {
        public static DiaryNoteVo ToDiaryNoteVo(this DiaryNoteDac noteDac)
        {
            if (noteDac == null) return null;

            return new DiaryNoteVo
            {
                Id = noteDac.Id,
                CreatedOn = noteDac.CreatedOn,
                Details = noteDac.Details,
                Summary = noteDac.Summary,
                Title = noteDac.NoteTitle,
                ModifiedOn = noteDac.ModifiedOn,
                IsDraft = noteDac.IsDraft.GetValueOrDefault()
            };
        }

        public static DiaryNoteDac ToDiaryNoteDac(this DiaryNoteVo noteVo)
        {
            if (noteVo == null) return null;

            return new DiaryNoteDac
            {
                Id = noteVo.Id,
                CreatedOn = noteVo.CreatedOn,
                Details = noteVo.Details,
                Summary = noteVo.Summary,
                NoteTitle = noteVo.Title,
                ModifiedOn = noteVo.ModifiedOn,
                IsDraft = noteVo.IsDraft
            };
        }
    }
}
