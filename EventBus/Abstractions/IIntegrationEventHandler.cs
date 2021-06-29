using EventBus.Events;
using System.Threading.Tasks;

namespace EventBus.Abstractions
{
    /// <summary>
    /// Manipulador de eventos de integração
    /// </summary>
    /// <typeparam name="TIntegrationEvent"></typeparam>
    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
        where TIntegrationEvent : IntegrationEvent
    {
        /// <summary>
        /// Manipulador
        /// </summary>
        /// <param name="event"></param>
        /// <returns></returns>
        Task Handle(TIntegrationEvent @event);
    }

    /// <summary>
    /// Manipulador de eventos de integração
    /// </summary>
    /// <typeparam name="TIntegrationEvent"></typeparam>
    public interface IIntegrationEventHandler { }
}
