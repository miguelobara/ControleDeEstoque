using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ControleDeEstoque.Helpers
{
    /// <summary>
    /// Classe com métodos de validação reutilizáveis
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// Valida CPF segundo algoritmo oficial
        /// </summary>
        public static bool ValidarCPF(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            // Remove caracteres não numéricos
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // Verifica se tem 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Verifica se todos os dígitos são iguais
            if (cpf.All(c => c == cpf[0]))
                return false;

            // Calcula primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (cpf[i] - '0') * (10 - i);

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            if (digito1 != (cpf[9] - '0'))
                return false;

            // Calcula segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (cpf[i] - '0') * (11 - i);

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            return digito2 == (cpf[10] - '0');
        }

        /// <summary>
        /// Valida CNPJ segundo algoritmo oficial
        /// </summary>
        public static bool ValidarCNPJ(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                return false;

            // Remove caracteres não numéricos
            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

            // Verifica se tem 14 dígitos
            if (cnpj.Length != 14)
                return false;

            // Verifica se todos os dígitos são iguais
            if (cnpj.All(c => c == cnpj[0]))
                return false;

            // Primeiro dígito verificador
            int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += (cnpj[i] - '0') * multiplicador1[i];

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            if (digito1 != (cnpj[12] - '0'))
                return false;

            // Segundo dígito verificador
            int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += (cnpj[i] - '0') * multiplicador2[i];

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            return digito2 == (cnpj[13] - '0');
        }

        /// <summary>
        /// Valida email usando regex
        /// </summary>
        public static bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
                return regex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Valida data de nascimento (não pode ser futura e idade mínima de 18 anos)
        /// </summary>
        public static bool ValidarDataNascimento(DateTime? data, bool verificarIdadeMinima = true)
        {
            if (!data.HasValue)
                return false;

            // Não pode ser data futura
            if (data.Value > DateTime.Now)
                return false;

            // Data muito antiga é inválida
            if (data.Value.Year < 1900)
                return false;

            // Verifica idade mínima se necessário
            if (verificarIdadeMinima)
            {
                var idade = DateTime.Now.Year - data.Value.Year;
                if (data.Value.Date > DateTime.Now.AddYears(-idade))
                    idade--;

                return idade >= 18;
            }

            return true;
        }

        /// <summary>
        /// Remove formatação de CPF/CNPJ/Telefone
        /// </summary>
        public static string RemoverFormatacao(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return string.Empty;

            return new string(texto.Where(char.IsDigit).ToArray());
        }

        /// <summary>
        /// Formata CPF (000.000.000-00)
        /// </summary>
        public static string FormatarCPF(string cpf)
        {
            cpf = RemoverFormatacao(cpf);
            if (cpf.Length != 11)
                return cpf;

            return $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9, 2)}";
        }

        /// <summary>
        /// Formata CNPJ (00.000.000/0000-00)
        /// </summary>
        public static string FormatarCNPJ(string cnpj)
        {
            cnpj = RemoverFormatacao(cnpj);
            if (cnpj.Length != 14)
                return cnpj;

            return $"{cnpj.Substring(0, 2)}.{cnpj.Substring(2, 3)}.{cnpj.Substring(5, 3)}/{cnpj.Substring(8, 4)}-{cnpj.Substring(12, 2)}";
        }

        /// <summary>
        /// Formata telefone brasileiro
        /// </summary>
        public static string FormatarTelefone(string telefone)
        {
            telefone = RemoverFormatacao(telefone);
            
            if (telefone.Length == 10)
                return $"({telefone.Substring(0, 2)}) {telefone.Substring(2, 4)}-{telefone.Substring(6, 4)}";
            
            if (telefone.Length == 11)
                return $"({telefone.Substring(0, 2)}) {telefone.Substring(2, 5)}-{telefone.Substring(7, 4)}";

            return telefone;
        }

        /// <summary>
        /// Formata CEP (00000-000)
        /// </summary>
        public static string FormatarCEP(string cep)
        {
            cep = RemoverFormatacao(cep);
            if (cep.Length != 8)
                return cep;

            return $"{cep.Substring(0, 5)}-{cep.Substring(5, 3)}";
        }

        /// <summary>
        /// Valida senha (mínimo 6 caracteres)
        /// </summary>
        public static bool ValidarSenha(string senha)
        {
            return !string.IsNullOrWhiteSpace(senha) && senha.Length >= 6;
        }
    }
}