using System;

namespace AvivatecParty.Domain.Entities.Participantes.Events
{
    public class ParticipanteRemovidoEvent : ParticipanteEvent
    {
        public ParticipanteRemovidoEvent(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}