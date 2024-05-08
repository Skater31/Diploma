using Server_SIde.DAL;
using Server_SIde.Interfaces;
using Server_SIde.Models;

namespace Server_SIde.Services
{
    public class PositionService : IPositionService
    {
        private readonly ApplicationContext _applicationContext;

        public PositionService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public IEnumerable<Position> GetAllPositions()
        {
            var positions = _applicationContext.Positions.ToList();

            return positions;
        }

        public void Add(Position position)
        {
            _applicationContext.Positions.Add(position);
            _applicationContext.SaveChanges();
        }

        public void Delete(Position position)
        {
            _applicationContext.Positions.Remove(position);
            _applicationContext.SaveChanges();
        }
    }
}
