using Server_SIde.DAL;
using Server_SIde.Interfaces;
using Server_SIde.Models;

namespace Server_SIde.Services
{
    public class MarkService : IMarkService
    {
        private readonly ApplicationContext _applicationContext;

        public MarkService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IEnumerable<Mark> GetAllMarks()
        {
            var marks = _applicationContext.Marks.ToList();

            return marks;
        }
    }
}
