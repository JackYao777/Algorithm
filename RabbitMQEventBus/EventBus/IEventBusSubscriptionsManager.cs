using RabbitMQEventBus.EventBusSubscrptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQEventBus.EventBus
{
    public interface IEventBusSubscriptionsManager
    {
        bool IsEmpty { get; }
        event EventHandler<string> OnEventRemoveHandler;
        void AddSubscription<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;

        void AddDynamicSubscription<TH>(string eventName) where TH : IDynamicIntegrationEventHandler;

        bool HasSubscriptionsForEvent(string eventName);

        string GetEventKey<T>();

        IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName);

        Type GetEventTypeName(string eventName);

        void Clear();
    }
}
