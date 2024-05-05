using Server_SIde.Models;

namespace Server_SIde.Interfaces
{
    public interface IMarkService
    {
        IEnumerable<Mark> GetAllMarks();
    }
}
