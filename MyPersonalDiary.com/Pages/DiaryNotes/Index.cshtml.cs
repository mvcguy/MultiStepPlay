using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyPersonalDiary.com.Domain.Repository;
using MyPersonalDiary.com.Domain.Services;

namespace MyPersonalDiary.com.Pages.DiaryNotes
{
    public class IndexModel : PageModel
    {
        public IndexModel(IDiaryService diaryService)
        {
            DiaryService = diaryService;
        }

        public IEnumerable<DiaryNoteVo> DiaryNoteDac { get;set; }

        public IDiaryService DiaryService { get; }

        public async Task OnGetAsync()
        {
            // conside range based on from and to date
            DiaryNoteDac = await DiaryService.GetAllNotes(null, null);
        }
    }
}
