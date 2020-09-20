using BusinessLogicLayer.ViewModels;
using DataAccessLayer.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeDTO> getAll();
    }
}
