using Microsoft.AspNetCore.Mvc;
using Server_SIde.Interfaces;
using Server_SIde.Models;

namespace Server_SIde.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IFreeEquipmentService _freeEquipmentService;

        public EmployeeController(IEmployeeService employeeService, IFreeEquipmentService freeEquipmentService)
        {
            _employeeService = employeeService;
            _freeEquipmentService = freeEquipmentService;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return _employeeService.GetAllEmployees();
        }

        [HttpPost]
        [Route("getById")]
        public async Task<Employee> GetById([FromBody] int id)
        {
            return _employeeService.GetById(id);
        }

        [HttpPost]
        [Route("getAllByEmployeeId")]
        public async Task<IEnumerable<FreeEquipment>> GetAllByEmployeeId([FromBody] int employeeId)
        {
            return _freeEquipmentService.GetAllByEmployeeId(employeeId);
        }

        [HttpPost]
        [Route("add")]
        public void Add(Employee employee)
        {
            _employeeService.Add(employee);
        }

        [HttpPost]
        [Route("edit")]
        public void Edit(Employee employee)
        {
            _employeeService.Edit(employee);
        }

        [HttpPost]
        [Route("delete")]
        public void Delete(Employee employee)
        {
            _employeeService.Delete(employee);
        }
    }
}
