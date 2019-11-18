using System;
using System.Collections.Generic;
using BotFactory.Common.Tools;
using BotFactory.Interface;

namespace BotFactory.Factories
{
    public interface IUnitFactory
    {
        Queue<IFactoryQueueElement> Queue { get; set; }
        int QueueCapacity { get; }
        int QueueFreeSlots { get; }
        List<ITestingUnit> Storage { get; set; }
        int StorageCapacity { get; }
        int StorageFreeSlots { get; }
        TimeSpan QueueTime { get; set; }
        event EventHandler FactoryProgress;

        bool AddWorkableUnitToQueue(Type model, string name, Coordinates parkingPos, Coordinates workingPos);
    }
}