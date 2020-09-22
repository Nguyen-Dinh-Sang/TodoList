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
    public class LoginModel : PageModel
    {
        IEmployeeService employeeService = new EmployeeService();
        public void OnGet()
        {
        }
        public void OnPost()
        {
            
            
            if(Request.Form["login_submit"].Equals("Sign In"))
            {
                var user = Request.Form["login_username"];
                var pass = Request.Form["login_password"];

                if (employeeService.login(user, pass).IdRole == 1)
                {
                    Response.Redirect("/user");
                }
            }
            else
            {
                if(Request.Form["registration_submit"].Equals("Sign Up") && Request.Form["registration_password"].Equals(Request.Form["registration_passwordRepeat"]))
                    {
                    EmployeeDTO employeeDTO = new EmployeeDTO();
                    employeeDTO.Id = 0;
                    employeeDTO.Email= Request.Form["registration_email"];
                    employeeDTO.FullName= Request.Form["registration_fullname"];
                    employeeDTO.Password= Request.Form["registration_password"];
                    employeeDTO.DateCreated= DateTime.Parse(Request.Form["registration_datecreated"]);
                    if(employeeService.checkEmailExists(employeeDTO.Email)==true)
                    {
                        Console.WriteLine("Email đã tồn tại");
                    }
                    else
                    {
                        employeeService.save(employeeDTO);
                    }    
                    
                    
                    }
            }    
                
   
            
            
        }
        
    }
}
