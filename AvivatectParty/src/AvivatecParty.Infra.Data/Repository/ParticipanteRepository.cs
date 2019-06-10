using AvivatecParty.Domain.Entities;
using AvivatecParty.Infra.Data.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AvivatecParty.Infra.Data.Repository
{
    public class ParticipanteRepository : Repository<Participante>, IParticipanteRepository
    {
        public ParticipanteRepository(AvivatecPartyContext context) : base(context)
        {
        }

        public IEnumerable<Local> GetAllLocais()
        {
            var sql = @"SELECT * FROM Locais";
            return Db.Database.GetDbConnection().Query<Local>(sql);
        }
    }
}