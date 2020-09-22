using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
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
            IEmployeeService employeeService = new EmployeeService();

            Console.WriteLine("GET ALL");
            foreach (var item in employeeService.getByIdWorkList(2))
            {
                Console.WriteLine("id = 3 " + item.FullName);
            }
            var employee = employeeService.login("giamdoc1@gmail.com", "12345");
            if (employee != null)
            {
                Console.WriteLine("LOGIN " + employee.FullName);
            } else
            {
                Console.WriteLine("LOGIN NULL");
            }
            Console.WriteLine("Check email " + employeeService.checkEmailExists("giamdoc1@gmail.com"));
            Console.WriteLine("Check email " + employeeService.checkEmailExists("phongchanly@gmail.com"));
            Console.WriteLine("Get by id 1 " + employeeService.getById(1).Email);
        }

        public void OnGet()
        {
        }
    }
}
