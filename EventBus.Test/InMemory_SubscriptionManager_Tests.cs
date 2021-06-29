using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace EventBus.Test
{
    [TestClass]
    public class InMemory_SubscriptionManager_Tests
    {
        private InMemoryEventBusSubscriptionsManager _manager;

        public InMemory_SubscriptionManager_Tests()
        {
            _manager = new InMemoryEventBusSubscriptionsManager();
        }

        [TestMethod]
        public void After_Creation_Should_Be_Empty()
        {
            Assert.IsTrue(_manager.IsEmpty);
        }

        [TestMethod]
        public void After_One_Event_Subscription_Should_Contain_The_Event()
        {
            _manager.AddSubscription<TestIntegrationEvent, TestIntegrationEventHandler>();
            Assert.IsTrue(_manager.HasSubscriptionsForEvent<TestIntegrationEvent>());
        }

        [TestMethod]
        public void After_All_Subscriptions_Are_Deleted_Event_Should_No_Longer_Exists()
        {
            var manager = new InMemoryEventBusSubscriptionsManager();
            manager.AddSubscription<TestIntegrationEvent, TestIntegrationEventHandler>();
            manager.RemoveSubscription<TestIntegrationEvent, TestIntegrationEventHandler>();
            Assert.IsFalse(manager.HasSubscriptionsForEvent<TestIntegrationEvent>());
        }

        [TestMethod]
        public void Deleting_Last_Subscription_Should_Raise_On_Deleted_Event()
        {
            bool raised = false;
            _manager = new InMemoryEventBusSubscriptionsManager();
            _manager.OnEventRemoved += (o, e) => raised = true;
            _manager.AddSubscription<TestIntegrationEvent, TestIntegrationEventHandler>();
            _manager.RemoveSubscription<TestIntegrationEvent, TestIntegrationEventHandler>();
            Assert.IsTrue(raised);
        }

        [TestMethod]
        public void Get_Handlers_For_Event_Should_Return_All_Handlers()
        {
            _manager.AddSubscription<TestIntegrationEvent, TestIntegrationEventHandler>();
            _manager.AddSubscription<TestIntegrationEvent, TestIntegrationOtherEventHandler>();
            var handlers = _manager.GetHandlersForEvent<TestIntegrationEvent>();
            Assert.AreEqual(2, handlers.Count());
        }

        [TestCleanup]
        public void CleanUp()
        {
            _manager = null;
        }

    }
}
