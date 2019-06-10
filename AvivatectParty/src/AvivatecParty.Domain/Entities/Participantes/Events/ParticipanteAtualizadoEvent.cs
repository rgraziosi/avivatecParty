namespace AvivatecParty.Domain.Entities.Participantes.Events
{
    public class ParticipanteAtualizadoEvent : ParticipanteEvent
    {
        public ParticipanteAtualizadoEvent(Participante participante)
        {
            Participante = participante;
            AggregateId = participante.Id;
        }
    }
}