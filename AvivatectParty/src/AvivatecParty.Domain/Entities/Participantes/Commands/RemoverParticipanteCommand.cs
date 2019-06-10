using System;

namespace AvivatecParty.Domain.Entities.Participantes.Commands
{
    public class RemoverParticipanteCommand : ParticipanteCommand
    {
        public RemoverParticipanteCommand(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}