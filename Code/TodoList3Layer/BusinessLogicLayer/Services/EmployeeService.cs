using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Mapping;
using BusinessLogicLayer.ViewModels;
using DataAccessLayer.Entitys;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLayer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeMapping employeeMapping = new EmployeeMapping();
        private IEmployeeRepository employeeRepository = new EmployeeRepository();
        List<EmployeeDTO> IEmployeeService.getAll()
        {
            return employeeMapping.toDTOs(employeeRepository.getAll());
        }
    }
}
