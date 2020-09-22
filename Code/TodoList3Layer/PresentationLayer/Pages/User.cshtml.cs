using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PresentationLayer.Pages
{   
    public class UserModel : PageModel
    {
        IEmployeeService employeeService = new EmployeeService();
        public void OnGet()
        {
        }
        public IEnumerable<EmployeeDTO> getAllEmployee()
        {
            return employeeService.getAll();
        }
    }
}
