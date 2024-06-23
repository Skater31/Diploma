using Microsoft.EntityFrameworkCore;
using Server_SIde.DAL;
using Server_SIde.Interfaces;
using Server_SIde.Models;

namespace Server_SIde.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationContext _applicationContext;

        public EmployeeService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            var employees = _applicationContext.Employees.
                Include("Position").ToList();

            return employees;
        }

        public Employee GetById(int id)
        {
            var employee = _applicationContext.Employees.
                Include("Position").
                FirstOrDefault(e => e.Id == id);

            return employee;
        }

        public void Add(Employee employee)
        {
            _applicationContext.Employees.Add(employee);
            _applicationContext.SaveChanges();
        }

        public void Edit(Employee employee)
        {
            _applicationContext.Employees.Update(employee);
            _applicationContext.SaveChanges();
        }

        public void Delete(Employee employee)
        {          
            _applicationContext.Employees.Remove(employee);
            _applicationContext.SaveChanges();
        }
    }
}
