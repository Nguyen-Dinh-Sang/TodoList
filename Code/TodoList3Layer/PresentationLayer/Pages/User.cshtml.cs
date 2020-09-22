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
        public string id=null;
        public string loai = null;
        IEmployeeService employeeService = new EmployeeService();
        public void OnGet()
        {
            if(Request.QueryString.HasValue == true)
            {
                var get = Request.QueryString.Value.Split('=');
                id = get[1];
                loai = get[0];
            }    
            
            
        }
        public IEnumerable<EmployeeDTO> getAllEmployee()
        {
            return employeeService.getAll();
        }
    }
}
