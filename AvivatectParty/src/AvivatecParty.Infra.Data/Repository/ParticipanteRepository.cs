using AvivatecParty.Domain.Entities;
using AvivatecParty.Infra.Data.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace AvivatecParty.Infra.Data.Repository
{
    public class ParticipanteRepository : Repository<Participante>, IParticipanteRepository
    {
        private readonly AvivatecPartyContext _context;
        public ParticipanteRepository(AvivatecPartyContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Local> GetAllLocais()
        {
            
            return _context.Locais.ToList();

            //Dapper Exemplo

            //var sql = @"SELECT * FROM Locais";
            //return Db.Database.GetDbConnection().Query<Local>(sql);
        }
    }
}