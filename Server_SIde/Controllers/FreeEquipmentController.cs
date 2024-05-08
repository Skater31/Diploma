using Microsoft.AspNetCore.Mvc;
using Server_SIde.Interfaces;
using Server_SIde.Models;

namespace Server_SIde.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FreeEquipmentController : Controller
    {
        private readonly IFreeEquipmentService _freeEquipmentService;

        public FreeEquipmentController(IFreeEquipmentService freeEquipmentService)
        {
            _freeEquipmentService = freeEquipmentService;
        }

        [HttpPost]
        [Route("getAllFreeEquipment")]
        public async Task<IEnumerable<FreeEquipment>> GetAllFreeEquipment([FromBody] int warehouseId)
        {
            return _freeEquipmentService.GetAllFreeEquipment(warehouseId);
        }

        [HttpGet]
        [Route("getAllFreeEquipment")]
        public async Task<IEnumerable<FreeEquipment>> GetAllFreeEquipment()
        {
            return _freeEquipmentService.GetAllFreeEquipment();
        }

        [HttpPost]
        [Route("getById")]
        public async Task<FreeEquipment> GetById([FromBody] int id)
        {
            return _freeEquipmentService.GetById(id);
        }

        [HttpPost]
        [Route("add")]
        public void Add(FreeEquipment freeEquipment)
        {
            _freeEquipmentService.Add(freeEquipment);
        }

        [HttpPost]
        [Route("edit")]
        public void Edit(FreeEquipment freeEquipment)
        {
            _freeEquipmentService.Edit(freeEquipment);
        }

        [HttpPost]
        [Route("delete")]
        public void Delete(FreeEquipment freeEquipment)
        {
            _freeEquipmentService.Delete(freeEquipment);
        }

        [HttpPost]
        [Route("find")]
        public async Task<IEnumerable<FreeEquipment>> Find([FromBody] string value)
        {
            var val = value.Split('+');

            return _freeEquipmentService.Find(val[0], int.Parse(val[1]));
        }
    }
}
