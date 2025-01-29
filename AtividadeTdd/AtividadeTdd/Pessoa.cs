using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AtividadeTdd
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public long CPF { get; set; }
        public string Celular { get; set; }
        public DateTime DataNascimento { get; set; }

        public bool ValidaNumeroCPF(long cpf)
        {
            string cpfString = cpf.ToString("D11"); // Converte para string com 11 dígitos

            if (cpfString.Length != 11)
                return false;

            // Verifica se todos os dígitos são iguais
            if (new string(cpfString[0], 11) == cpfString)
                return false;

            // Calcula o primeiro dígito verificador
            int[] multiplicadores1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (cpfString[i] - '0') * multiplicadores1[i];

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            // Calcula o segundo dígito verificador
            int[] multiplicadores2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (cpfString[i] - '0') * multiplicadores2[i];

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            // Verifica se os dígitos calculados são iguais aos dígitos do CPF
            return cpfString[9] - '0' == digito1 && cpfString[10] - '0' == digito2;
        }

        public bool ValidaDataNascimento(DateTime dataNascimento)
        {
            return dataNascimento <= DateTime.Today;
        }

        public bool ValidaFormatoCelular(string celular)
        {
            // Remove caracteres não numéricos
            string apenasNumeros = Regex.Replace(celular, @"\D", "");
            // Verifica se tem exatamente 11 dígitos
            if (apenasNumeros.Length != 11)
            {
                return false;
            }
            // Regex para validar o formato do celular com ou sem traço
            string pattern = @"^\(?\d{2}\)? ?\d{4,5}-?\d{4}$";
            return Regex.IsMatch(celular, pattern);
        }
    }
}