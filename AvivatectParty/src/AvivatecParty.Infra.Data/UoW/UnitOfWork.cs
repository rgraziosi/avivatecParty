using AvivatecParty.Domain.Core.Commands;
using AvivatecParty.Domain.Interface;
using AvivatecParty.Infra.Data.Context;

namespace AvivatecParty.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AvivatecPartyContext _context;

        public UnitOfWork(AvivatecPartyContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}