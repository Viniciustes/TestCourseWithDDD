using ExpectedObjects;
using System;
using TestCourseWithDDD.Test.Exceptions;
using Xunit;

namespace TestCourseWithDDD.Test.CursoTests
{
    public class CursoTest
    {
        private readonly double _valor;
        private readonly double _cargaHoraria;
        private readonly string _nome;
        private readonly PublicoAlvo _publicoAlvo;

        public CursoTest()
        {
            _valor = (double)950;
            _cargaHoraria = (double)80;
            _nome = "Informática";
            _publicoAlvo = PublicoAlvo.Universitário;
        }

        [Fact]
        public void DeveCriarCurso()
        {
            var cursoEsperado = new
            {
                Valor = _valor,
                CargaHoraria = _cargaHoraria,
                Nome = _nome,
                PublicoAlvo = _publicoAlvo,
            };

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.PublicoAlvo, cursoEsperado.Valor, cursoEsperado.CargaHoraria);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void NomeNaoPodeSerInvalido(string nomeInvalido)
        {
            Assert.Throws<ArgumentException>(() => new Curso(nomeInvalido, _publicoAlvo, _valor, _cargaHoraria)).WithMessage("Nome Inválido!");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(0.9)]
        [InlineData(-2)]
        public void CargaHorariaNaoPodeSerMenorQue1(double cargaHorariaInvalida)
        {
            Assert.Throws<ArgumentException>(() => new Curso(_nome, _publicoAlvo, _valor, cargaHorariaInvalida)).WithMessage("Carga Horária Inválida!");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void ValorDoCursoDeveSerMaiorQue0(double valorInvalido)
        {
            Assert.Throws<ArgumentException>(() => new Curso(_nome, _publicoAlvo, valorInvalido, _cargaHoraria)).WithMessage("Valor Inválido!");
        }
    }

    public enum PublicoAlvo
    {
        Estudante,
        Universitário,
        Empregado,
        Empreendedor
    }

    public class Curso
    {
        public Curso(string nome, PublicoAlvo publicoAlvo, double valor, double cargaHoraria)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome Inválido!");

            if (cargaHoraria < 1)
                throw new ArgumentException("Carga Horária Inválida!");

            if (valor <= 0)
                throw new ArgumentException("Valor Inválido!");

            Nome = nome;
            Valor = valor;
            PublicoAlvo = publicoAlvo;
            CargaHoraria = cargaHoraria;
        }

        public string Nome { get; private set; }
        public double Valor { get; private set; }
        public double CargaHoraria { get; private set; }
        public PublicoAlvo PublicoAlvo { get; private set; }
    }
}