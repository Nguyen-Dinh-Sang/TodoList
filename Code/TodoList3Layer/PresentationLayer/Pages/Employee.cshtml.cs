using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Providers.Entities;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PresentationLayer.Pages
{   
    public class EmployeeModel : PageModel
    {
        public string id=null;
        public string loai = null;
        private string loaisession, idsession = null;
        IEmployeeService employeeService = new EmployeeService();
        IWorkListService workListService = new WorkListService();
        public void OnGet()
        {
            if(Request.QueryString.HasValue == true)
            {
                var get = Request.QueryString.Value.Split('=');
                id = get[1];
                loai = get[0];
                if(loai!=null && id!=null)
                {
                    HttpContext.Session.SetString("loai", loai + "");
                    HttpContext.Session.SetString("id", id + "");
                    if(loai.Equals("?id"))
                    {
                        HttpContext.Session.SetString("id_employee", id + "");
                    }
                    if (loai.Equals("?danhsachcongviec"))
                    {
                        HttpContext.Session.SetString("id_worklist", id + "");
                    }
                    if (loai.Equals("?congviec"))
                    {
                        HttpContext.Session.SetString("id_work", id + "");
                    }
                }    
                
            }    
            
            
        }
        public void OnPost()
        {
            deleteWorkList();  
        }
        public void deleteWorkList()
        {
            workListService.remove(int.Parse(Request.Form["id_delete"]));
            Response.Redirect("/employee" + HttpContext.Session.GetString("loai") + "=" + HttpContext.Session.GetString("id"));
        }
        public string getSessionLoai()
        {
            return HttpContext.Session.GetString("loai");
        }
        public string getSessionId()
        {
            return HttpContext.Session.GetString("id");
        }
        public string getid_employee()
        {
            return HttpContext.Session.GetString("id_employee");
        }
        public string getid_worklist()
        {
            return HttpContext.Session.GetString("id_worklist");
        }
        public string getid_work()
        {
            return HttpContext.Session.GetString("id_work");
        }
        public string getSessionFullname()
        {
            return HttpContext.Session.GetString("fullname");
        }
        public string getSessionIdrole()
        {
            return HttpContext.Session.GetString("idrole");
        }
        public IEnumerable<WorkListDTO> getAllByIdEmployee()
        {
            return workListService.getAllByIdEmployee(int.Parse(HttpContext.Session.GetString("id")));
        }
        public IEnumerable<EmployeeDTO> getAllEmployee()
        {
            return employeeService.getAll();
        }
    }
}
