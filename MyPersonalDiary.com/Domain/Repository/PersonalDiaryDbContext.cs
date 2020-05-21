using Microsoft.EntityFrameworkCore;

namespace MyPersonalDiary.com.Domain.Repository
{
    public class PersonalDiaryDbContext : DbContext
    {
        public PersonalDiaryDbContext(DbContextOptions<PersonalDiaryDbContext> options) : base(options)
        {

        }

        public DbSet<DiaryNoteDac> DiaryNotes { get; set; }
    }
}
