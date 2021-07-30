using SelecaoBRQ.Domain.Core.Models;
using SelecaoBRQ.Domain.Core.ValueObjects;

namespace SelecaoBRQ.Domain.Domains
{
    public partial class Usuario : Entity<Usuario>
    {
        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Sexo { get; set; }

        public string DataNascimento { get; set; }

        public override bool IsValid()
        {
            //FE5.3.1 - Campos obrigatorios
            //RuleFor(x => x.TipoEntidadeId)
            //    .NotEmpty().WithMessage(CommonMessageResource.CampoObrigatorio.ToStringFormat("Tipo de Entidade"));

            //RuleFor(x => x.TipoVisitaId)
            //    .NotEmpty().WithMessage(CommonMessageResource.CampoObrigatorio.ToStringFormat("Tipo da Visita"));

            //RuleFor(x => x.DataInicioVigencia)
            //    .NotEmpty().WithMessage(CommonMessageResource.CampoObrigatorio.ToStringFormat("Vigência Inicial"));

            //RuleFor(x => x.DataFimVigencia)
            //    .NotEmpty().WithMessage(CommonMessageResource.CampoObrigatorio.ToStringFormat("Vigência Final"));

            //RuleFor(x => x.DescricaoFormularioVisita)
            //    .NotEmpty().WithMessage(CommonMessageResource.CampoObrigatorio.ToStringFormat("Descrição"));

            //RuleFor(x => x.Situacao)
            //    .NotEmpty().WithMessage(CommonMessageResource.CampoObrigatorio.ToStringFormat("Situação"));

            //FE5.3.4 - Vigencia final menor que a vigencia final
            //RuleFor(x => x.DataFimVigencia.Value)
            //    .GreaterThanOrEqualTo(x => x.DataInicioVigencia.Value)
            //    .WithMessage(CommonMessageResource.ValidarDataVigencia.ToString());

            ValidationResult = Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
