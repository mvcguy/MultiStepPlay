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
    public class DetailsModel : PageModel
    {
        public DetailsModel(IDiaryService diaryService)
        {
            DiaryService = diaryService;
        }

        public DiaryNoteVo DiaryNoteVo { get; set; }
        public IDiaryService DiaryService { get; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DiaryNoteVo = await DiaryService.GetNoteById(id);

            if (DiaryNoteVo == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
