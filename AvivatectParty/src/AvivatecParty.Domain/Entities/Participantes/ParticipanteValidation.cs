using FluentValidation;
using FluentValidation.Results;
using System;

namespace AvivatecParty.Domain.Entities
{
    internal class ParticipanteValidation : AbstractValidator<Participante>
    {
        #region [ Propeties ]

        public ValidationResult ValidationResult { get; protected set; }

        #endregion [ Propeties ]

        #region [ Methods ]

        public bool Valido(Participante objValidar)
        {
            ValidarNome();
            ValidarSenha();
            ValidarEmail();
            ValidarLogin();
            ValidarMelhorDiaHora(objValidar);

            ValidationResult = Validate(objValidar);

            return ValidationResult.IsValid;
        }

        #endregion [ Methods ]

        #region [ Methods Private ]

        private void ValidarNome()
        {
            RuleFor(obj => obj.Nome)
                .NotEmpty().WithMessage(Messages.MSG_PARTICIPANTE_NOME_NULL)
                .Length(2, 50).WithMessage(Messages.MSG_PARTICIPANTE_NOME_MIN_MAX);
        }

        private void ValidarSenha()
        {
            RuleFor(obj => obj.Senha)
                .NotEmpty().WithMessage(Messages.MSG_PARTICIPANTE_SENHA_NULL)
                .Length(5, 20).WithMessage(Messages.MSG_PARTICIPANTE_SENHA_MIN_MAX);
                //.Matches(".*([A-Za-z][0-9]|[0-9][A-Za-z]).*").WithMessage(Messages.MSG_PARTICIPANTE_SENHA_VALIDO);
        }

        private void ValidarEmail()
        {
            RuleFor(obj => obj.Email)
                .NotEmpty().WithMessage(Messages.MSG_PARTICIPANTE_EMAIL_NULL)
                .Length(0, 150).WithMessage(Messages.MSG_PARTICIPANTE_EMAIL_VALIDO)
                .Matches(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})$").WithMessage(Messages.MSG_PARTICIPANTE_EMAIL_VALIDO);
        }

        private void ValidarLogin()
        {
            RuleFor(obj => obj.Login)
                .NotEmpty().WithMessage(Messages.MSG_PARTICIPANTE_LOGIN_NULL)
                .Length(2, 15).WithMessage(Messages.MSG_PARTICIPANTE_LOGIN_MIN_MAX);
        }

        private void ValidarMelhorDiaHora(Participante objValidar)
        {
            if (objValidar.MelhorDiaHora != null)
                RuleFor(obj => obj.MelhorDiaHora)
                    .GreaterThanOrEqualTo(DateTime.Now).WithMessage(Messages.MSG_PARTICIPANTE_MELHORDIAHORA_VALIDO);
        }

        #endregion [ Methods Private ]
    }
}