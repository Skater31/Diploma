using Microsoft.AspNetCore.Mvc;
using Server_SIde.Interfaces;
using Server_SIde.Models;

namespace Server_SIde.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MarkController : Controller
    {
        private readonly IMarkService _markService;

        public MarkController(IMarkService markService)
        {
            _markService = markService;
        }

        [HttpGet]
        public async Task<IEnumerable<Mark>> GetAllMarks()
        {
            return _markService.GetAllMarks();
        }
    }
}
