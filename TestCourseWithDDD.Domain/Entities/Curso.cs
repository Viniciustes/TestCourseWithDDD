using System;
using TestCourseWithDDD.Domain.Enums;

namespace TestCourseWithDDD.Domain.Entities
{
    public class Curso : Entity
    {
        public Curso(string nome, PublicoAlvo publicoAlvo, double valor, string descricao, double cargaHoraria, DateTime dataCadastro, bool ativo)
        {
            Nome = nome;
            Valor = valor;
            Descricao = descricao;
            PublicoAlvo = publicoAlvo;
            DataCadastro = dataCadastro;
            CargaHoraria = cargaHoraria;
            Ativo = ativo;

            ValidaCampos();
        }

        public string Nome { get; }
        public double Valor { get; }
        public string Descricao { get; }
        public double CargaHoraria { get; }
        public DateTime DataCadastro { get; }
        public PublicoAlvo PublicoAlvo { get; }
        public bool Ativo { get; }

        private void ValidaCampos()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new ArgumentException("Nome Inválido!");

            if (CargaHoraria < 1)
                throw new ArgumentException("Carga Horária Inválida!");

            if (Valor <= 0)
                throw new ArgumentException("Valor Inválido!");
        }
    }
}