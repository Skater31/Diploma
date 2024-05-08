using Server_SIde.Models;

namespace Server_SIde.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();

        Employee GetById(int id);

        void Add(Employee employee);

        void Edit(Employee employee);

        void Delete(Employee employee);
    }
}
