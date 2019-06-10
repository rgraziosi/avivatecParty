using AvivatecParty.Domain.Core.Events.Interfaces;

namespace AvivatecParty.Domain.Entities.Participantes.Events
{
    public class ParticipanteEventHandler :
        IHandler<ParticipanteResgistradoEvent>,
        IHandler<ParticipanteAtualizadoEvent>,
        IHandler<ParticipanteRemovidoEvent>
    {
        public void Handle(ParticipanteResgistradoEvent message)
        {
            // Log ou enviar email
        }

        public void Handle(ParticipanteAtualizadoEvent message)
        {
            // Log ou enviar email
        }

        public void Handle(ParticipanteRemovidoEvent message)
        {
            // Log ou enviar email
        }
    }
}