using BotFactory.Common.Tools;
using BotFactory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BotFactory.Factories
{
    public class UnitFactory : IUnitFactory
    {
        private object _mutex = new object();
        private IFactoryQueueElement _iFactoryQueueElement;
        public event EventHandler FactoryProgress;
        public int QueueCapacity { get; private set; }
        public int StorageCapacity { get; private set; }
        public Queue<IFactoryQueueElement> Queue { get; set; }
        public List<ITestingUnit> Storage { get; set; }

        public int QueueFreeSlots
        {
            get
            {
                return QueueCapacity - Queue.Count;
            }
        }
        public int StorageFreeSlots
        {
            get
            {
                return StorageCapacity - Storage.Count;
            }
        }
        public TimeSpan QueueTime { get; set; }
        public UnitFactory(int queueCapacity, int storageCapacity)
        {
            QueueCapacity = queueCapacity >= 0 ? queueCapacity : 0;
            StorageCapacity = storageCapacity >= 0 ? storageCapacity : 0;
            Queue = new Queue<IFactoryQueueElement>();
            Storage = new List<ITestingUnit>();
        }
        public bool AddWorkableUnitToQueue(Type model, string name, Coordinates parkingPos, Coordinates workingPos)
        {
            var isAdded = false;
            if (Queue.Count < QueueCapacity)
            {

                FactoryQueueElement queueElement = new FactoryQueueElement();
                queueElement.Model = model;
                queueElement.Name = name;
                queueElement.ParkingPos = parkingPos;
                queueElement.WorkingPos = workingPos;
                _iFactoryQueueElement = queueElement;
                Queue.Enqueue(_iFactoryQueueElement);
                isAdded = true;
                var createThread = new Thread(new ThreadStart(CreateUnit));
                createThread.Start();

            }
            return isAdded;
        }

        private void CreateUnit()
        {

            lock (_mutex)
            {
                if (Storage.Count < StorageCapacity)
                {
                    IFactoryQueueElement elementToCreate = Queue.Peek();
                    var modelInstance = Activator.CreateInstance(elementToCreate.Model);
                    ITestingUnit testingUnit = (ITestingUnit)modelInstance;
                    testingUnit.Name = elementToCreate.Name;
                    testingUnit.ParkingPos = elementToCreate.ParkingPos;
                    testingUnit.WorkingPos = elementToCreate.WorkingPos;
                    FactoryProgressEventArgs arg = new FactoryProgressEventArgs();
                    arg.NewStatus = "Creation start";
                    arg.QueueElement = elementToCreate;
                    OnStatusChanged(arg);
                    var buildTime = testingUnit.BuildTime;
                    Thread.Sleep(TimeSpan.FromSeconds(buildTime));
                    QueueTime = TimeSpan.FromSeconds(buildTime);
                    Queue.Dequeue();
                    Storage.Add(testingUnit);
                    arg = new FactoryProgressEventArgs();
                    arg.NewStatus = "Creation end";
                    arg.TestingUnit = testingUnit;
                    OnStatusChanged(arg);
                }

            }
        }

        protected virtual void OnStatusChanged(IFactoryProgressEventArgs args)
        {
            FactoryProgress?.Invoke(this, (FactoryProgressEventArgs)args);
        }
    }
}
