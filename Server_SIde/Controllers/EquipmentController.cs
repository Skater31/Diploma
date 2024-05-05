using Microsoft.AspNetCore.Mvc;
using Server_SIde.Interfaces;
using Server_SIde.Models;

namespace Server_SIde.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EquipmentController : Controller
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet]
        public async Task<IEnumerable<Equipment>> GetAllEquipmet()
        {
            return _equipmentService.GetAllEquipment();
        }

        [HttpPost]
        [Route("getById")]
        public async Task<Equipment> GetById([FromBody] int id)
        {
            return _equipmentService.GetById(id);
        }

        [HttpPost]
        [Route("add")]
        public void Add(Equipment equipment)
        {
            _equipmentService.Add(equipment);
        }

        [HttpPost]
        [Route("edit")]
        public void Edit(Equipment equipment)
        {
            _equipmentService.Edit(equipment);
        }

        [HttpPost]
        [Route("delete")]
        public void Delete(Equipment equipment)
        {
            _equipmentService.Delete(equipment);
        }

        [HttpPost]
        [Route("find")]
        public async Task<IEnumerable<Equipment>> Find([FromBody] string value)
        {
            return _equipmentService.Find(value);
        }
    }
}
