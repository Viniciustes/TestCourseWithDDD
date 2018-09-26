using System;
using TestCourseWithDDD.Domain.Enums;

namespace TestCourseWithDDD.Domain.Entities
{
    public class Curso
    {
        public Curso(string nome, PublicoAlvo publicoAlvo, double valor, string descricao, double cargaHoraria, DateTime dataCadastro)
        {
            ValidaCampos(nome, valor, cargaHoraria);

            Nome = nome;
            Valor = valor;
            Descricao = descricao;
            PublicoAlvo = publicoAlvo;
            DataCadastro = dataCadastro;
            CargaHoraria = cargaHoraria;
        }

        public string Nome { get; private set; }
        public double Valor { get; private set; }
        public string Descricao { get; private set; }
        public double CargaHoraria { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }

        private static void ValidaCampos(string nome, double valor, double cargaHoraria)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome Inválido!");

            if (cargaHoraria < 1)
                throw new ArgumentException("Carga Horária Inválida!");

            if (valor <= 0)
                throw new ArgumentException("Valor Inválido!");
        }
    }
}