using AvivatecParty.Domain.Core.Events;
using System;

namespace AvivatecParty.Domain.Entities.Participantes.Events
{
    public abstract class ParticipanteEvent : Event
    {
        public Guid Id { get; protected set; }

        public Participante Participante { get; protected set; }
    }
}