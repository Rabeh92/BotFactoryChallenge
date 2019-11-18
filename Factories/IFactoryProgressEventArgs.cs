using BotFactory.Interface;

namespace BotFactory.Factories
{
    public interface IFactoryProgressEventArgs
    {
        string NewStatus { get; set; }
        IFactoryQueueElement QueueElement { get; set; }
        ITestingUnit TestingUnit { get; set; }
    }
}