using System.Text.RegularExpressions;

namespace SelecaoBRQ.Domain.Core.ValueObjects
{
    public sealed class Email
    {
        public const int EnderecoMaxLength = 254;

        public const int EnderecoMinLength = 5;

        public string Endereco { get; private set; }

        public Email() { }

        public Email(string endereco)
        {
            Endereco = endereco;
        }

        public string ObterDominio()
        {
            return Endereco[(Endereco.IndexOf('@') + 1)..];
        }

        public static bool EhValido(string email)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            return regexEmail.IsMatch(email);
        }
    }
}
