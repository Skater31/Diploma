using Server_SIde.Models;

namespace Server_SIde.Interfaces
{
    public interface IPositionService
    {
        IEnumerable<Position> GetAllPositions();

        void Add(Position position);

        void Delete(Position position);
    }
}
