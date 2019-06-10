using AvivatecParty.Domain.Core.Entites;
using System;
using System.Collections.Generic;

namespace AvivatecParty.Domain.Entities
{
    public class Local : Entity<Local>
    {
        #region [ Constructor ]

        public Local(Guid id)
        {
            Id = id;
        }

        #endregion [ Constructor ]

        #region [ Propeties ]

        public string Nome { get; private set; }

        #endregion [ Propeties ]

        #region [ EF ]

        public virtual ICollection<Participante> Participantes { get; set; }

        protected Local()
        {
        }

        #endregion [ EF ]

        public override bool Valido()
        {
            return true;
        }
    }
}