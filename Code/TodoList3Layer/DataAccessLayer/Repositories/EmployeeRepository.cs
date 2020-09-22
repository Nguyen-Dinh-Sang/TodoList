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

        public IEnumerable<Employee> getAll()
        {
            return todoListDBContext.Employee;
        }

        public Employee getById(int id)
        {
            return todoListDBContext.Employee.Find(id);
        }

        public IEnumerable<Employee> getByIdWorkList(int id)
        {
            /*
            var result = from m in todoListDBContext.Employee
                         where m.Id.Contains((from x in todoListDBContext.WorkListEmployee
                                             where x.IdWorkList == id
                                              select x.IdEmployee))
                         select m;
                         */
            var result2 = from e in todoListDBContext.Employee
                          join wle in todoListDBContext.WorkListEmployee on e.Id equals wle.IdEmployee
                          where wle.IdWorkList == id 
                         select e;
            return result2;
        }

        public Employee login(string email, string password)
        {
            var result = from m in todoListDBContext.Employee
                           where m.Email == email && m.Password == password
                           select m;

            return result.Count() > 0 ? result.First() : null;
        }

        public Employee save(Employee employee)
        {
            if (employee.Id == 0)
            {
                var result = todoListDBContext.Employee.Add(employee);
                todoListDBContext.SaveChanges();
                return result.Entity;
            } else
            {
                Employee findResult = todoListDBContext.Employee.Find(employee.Id);
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
