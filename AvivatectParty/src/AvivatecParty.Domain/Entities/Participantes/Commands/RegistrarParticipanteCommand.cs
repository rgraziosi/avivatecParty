namespace AvivatecParty.Domain.Entities.Participantes.Commands
{
    public class RegistrarParticipanteCommand : ParticipanteCommand
    {
        public RegistrarParticipanteCommand(Participante participante)
        {
            Participante = participante;
        }
    }
}