using System.Threading.Tasks;

namespace EventBus.Abstractions
{
    /// <summary>
    /// Manipulador de eventos de integração dinamicos
    /// </summary>
    public interface IDynamicIntegrationEventHandler
    {
        /// <summary>
        /// Manipulador
        /// </summary>
        /// <param name="eventData"></param>
        /// <returns></returns>
        Task Handle(dynamic eventData);
    }
}
