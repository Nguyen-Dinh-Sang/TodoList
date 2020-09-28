using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace PresentationLayer.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;

            IWorkService workService = new WorkService();
            WorkDTO work = new WorkDTO();
            work.Id = 0;
            work.IdWorkList = 1;
            work.WorkContent = "mưới tạo";
            workService.save(work, 3);
        }

        public void OnGet()
        {
        }
    }
}
