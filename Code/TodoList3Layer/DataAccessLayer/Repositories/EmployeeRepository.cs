using DataAccessLayer.Context;
using DataAccessLayer.Entitys;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private  TodoListDBContext todoListDBContext = TodoListDBContext.getInstance();

        public bool checkEmailExists(string email)
        {
            return todoListDBContext.Employee.Count(x => x.Email == email) > 0;
        }

        public IEnumerable<EmployeeEntity> getAll()
        {
            return todoListDBContext.Employee;
        }

        public EmployeeEntity getById(int id)
        {
            return todoListDBContext.Employee.Find(id);
        }

        public EmployeeEntity login(string email, string password)
        {
            var result = from m in todoListDBContext.Employee.Cast<EmployeeEntity>()
                           where m.Email == email && m.Password == password
                           select m;

            return result.Count() > 0 ? result.First() : null;
        }

        public EmployeeEntity save(EmployeeEntity employee)
        {
            if (employee.Id == 0)
            {
                var result = todoListDBContext.Employee.Add(employee);
                todoListDBContext.SaveChanges();
                return result.Entity;
            } else
            {
                EmployeeEntity findResult = todoListDBContext.Employee.Find(employee.Id);
                findResult.Password = employee.Password;
                findResult.FullName = employee.FullName;
                findResult.PhoneNumber = employee.PhoneNumber;
                findResult.IdRole = employee.IdRole;
                todoListDBContext.SaveChanges();
                return todoListDBContext.Employee.Find(employee.Id);
            }
            
        }
    }
}
