using System.Threading.Tasks;
using BotFactory.Common.Tools;

namespace BotFactory.Interface
{
    public interface IBaseUnit
    {
        Coordinates CurrentPos { get; set; }
        string Name { get; set; }
        double Speed { get; set; }

        Task<bool> MoveAsync(Coordinates currentPos, Coordinates targetPos);
    }
}