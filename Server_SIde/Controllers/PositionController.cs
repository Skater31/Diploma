using Microsoft.AspNetCore.Mvc;
using Server_SIde.Interfaces;
using Server_SIde.Models;
using Server_SIde.Services;

namespace Server_SIde.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PositionController : Controller
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet]
        public async Task<IEnumerable<Position>> GetAllPositions()
        {
            return _positionService.GetAllPositions();
        }

        [HttpPost]
        [Route("add")]
        public void Add(Position position)
        {
            _positionService.Add(position);
        }

        [HttpPost]
        [Route("delete")]
        public void Delete(Position position)
        {
            _positionService.Delete(position);
        }
    }
}
