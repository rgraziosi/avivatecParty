namespace AvivatecParty.Domain.Entities.Participantes.Events
{
    public class ParticipanteResgistradoEvent : ParticipanteEvent
    {
        public ParticipanteResgistradoEvent(Participante participante)
        {
            Participante = participante;
            AggregateId = participante.Id;
        }
    }
}