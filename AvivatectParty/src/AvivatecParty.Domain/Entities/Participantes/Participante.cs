using AvivatecParty.Domain.Core.Entites;
using System;

namespace AvivatecParty.Domain.Entities
{
    public class Participante : Entity<Participante>
    {
        #region [ Constructors ]

        public Participante(string nome, string email, string login, string senha, DateTime melhorDiaHora, bool organizador)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            Login = login;
            Senha = senha;
            MelhorDiaHora = melhorDiaHora;
            Organizador = organizador;
        }

        private Participante()
        {
        }

        #endregion [ Constructors ]

        #region [ Properties ]

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public DateTime? MelhorDiaHora { get; private set; }
        public Guid? LocalId { get; private set; }
        public bool Organizador { get; private set; }
        public bool Removido { get; private set; }

        #endregion [ Properties ]

        #region [ EF ]

        public virtual Local Local { get; private set; }

        public void AtribuirLocal(Local local)
        {
            if (!Local.Valido()) return;
            Local = local;
        }

        #endregion [ EF ]

        #region [ Methods ]

        public override bool Valido()
        {
            ParticipanteValidation objValidate = new ParticipanteValidation();

            bool Valido = objValidate.Valido(this);
            ValidationResult = objValidate.ValidationResult;

            return Valido;
        }

        #endregion [ Methods ]

        #region [ Factory ]

        public static class ParticipanteFactory
        {
            public static Participante NovoParticipanteCompleto(Guid Id, string nome, string email, string login, string senha, DateTime melhorDiaHora, Guid localId, bool organizador)
            {
                Participante participante = new Participante()
                {
                    Id = Id,
                    Nome = nome,
                    Email = email,
                    Login = login,
                    Senha = senha,
                    MelhorDiaHora = melhorDiaHora,
                    LocalId = localId,
                    Organizador = organizador
                };

                return participante;
            }
        }

        #endregion [ Factory ]
    }
}