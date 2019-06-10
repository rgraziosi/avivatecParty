namespace AvivatecParty.Domain.Entities.Participantes.Commands
{
    public class AtualizarParticipanteCommand : ParticipanteCommand
    {
        public AtualizarParticipanteCommand(Participante participante)
        {
            Participante = participante;
        }
    }
}