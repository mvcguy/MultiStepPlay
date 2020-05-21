using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyPersonalDiary.com.Domain.Repository;
using MyPersonalDiary.com.Domain.Services;

namespace MyPersonalDiary.com.Pages.DiaryNotes
{
    public class EditModel : PageModel
    {
        public EditModel(IDiaryService diaryService)
        {
            DiaryService = diaryService;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await DiaryService.UpdateNote(DiaryNoteVo);

            return RedirectToPage("./Index");
        }

    }
}
