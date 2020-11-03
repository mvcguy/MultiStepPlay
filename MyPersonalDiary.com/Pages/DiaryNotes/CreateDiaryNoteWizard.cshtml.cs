using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyPersonalDiary.com.Domain.Services;

namespace MyPersonalDiary.com.Pages.DiaryNotes
{
    public class CreateDiaryNoteWizardModel : PageModel
    {
        public CreateDiaryNoteWizardModel(IDiaryService diaryService)
        {
            DiaryService = diaryService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DiaryNoteVo DiaryNoteVo { get; set; }
        public IDiaryService DiaryService { get; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            await DiaryService.AddNote(DiaryNoteVo);

            return RedirectToPage("./Index");
        }
    }
}