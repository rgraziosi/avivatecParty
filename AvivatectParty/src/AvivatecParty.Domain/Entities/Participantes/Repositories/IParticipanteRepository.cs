using AvivatecParty.Domain.Interface;
using System.Collections.Generic;

namespace AvivatecParty.Domain.Entities
{
    public interface IParticipanteRepository : IRepository<Participante>
    {
        IEnumerable<Local> GetAllLocais();
    }
}