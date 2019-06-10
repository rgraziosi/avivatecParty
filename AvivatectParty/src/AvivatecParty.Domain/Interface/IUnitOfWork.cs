using AvivatecParty.Domain.Core.Commands;
using System;

namespace AvivatecParty.Domain.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}