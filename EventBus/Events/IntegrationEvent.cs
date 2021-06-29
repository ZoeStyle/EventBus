using System;
using System.Text.Json.Serialization;

namespace EventBus.Events
{
    /// <summary>
    /// Evento de integração
    /// </summary>
    public record IntegrationEvent
    {
        /// <summary>
        /// constructor
        /// </summary>
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Json Contructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="createDate"></param>
        [JsonConstructor]
        public IntegrationEvent(Guid id, DateTime createDate)
        {
            Id = id;
            CreationDate = createDate;
        }

        /// <summary>
        /// Hash de id do evento
        /// </summary>
        [JsonInclude]
        public Guid Id { get; private init; }

        /// <summary>
        /// Data de criação do envento
        /// </summary>
        [JsonInclude]
        public DateTime CreationDate { get; private init; }
    }
}
