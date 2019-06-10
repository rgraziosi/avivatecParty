using AvivatecParty.Domain.Core.Commands;
using System;

namespace AvivatecParty.Domain.Entities.Participantes.Commands
{
    public abstract class ParticipanteCommand : Command
    {
        public Guid Id { get; protected set; }

        public Participante Participante { get; protected set; }
    }
}