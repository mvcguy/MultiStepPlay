using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MyPersonalDiary.com.Domain.Services;

namespace MyPersonalDiary.com.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IDiaryService diaryService)
        {
            _logger = logger;
            DiaryService = diaryService;
        }

        public IDiaryService DiaryService { get; }

        public IEnumerable<DiaryNoteVo> DiaryNotes { get; set; }

        public async Task OnGetAsync()
        {
            DiaryNotes = await DiaryService.GetAllNotes(null, null);
        }
    }
}
