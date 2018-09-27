using Bogus;
using ExpectedObjects;
using System;
using TestCourseWithDDD.Domain.Entities;
using TestCourseWithDDD.Domain.Enums;
using TestCourseWithDDD.Test.Builders;
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
        private readonly string _descricao;
        private readonly DateTime _dataCadastro;
        private readonly bool _ativo;

        public CursoTest()
        {
            var faker = new Faker();

            _valor = faker.Random.Double(100,5000);
            _cargaHoraria = faker.Random.Double(1, 100);
            _nome = faker.Random.Word();
            _publicoAlvo = faker.Random.Enum<PublicoAlvo>();
            _descricao = faker.Lorem.Paragraph();
            _dataCadastro = DateTime.Now;
            _ativo = faker.Random.Bool();
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
                Descricao = _descricao,
                DataCadastro = _dataCadastro,
                Ativo = _ativo
            };

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.PublicoAlvo, cursoEsperado.Valor, cursoEsperado.Descricao, cursoEsperado.CargaHoraria, cursoEsperado.DataCadastro, cursoEsperado.Ativo);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void NomeNaoPodeSerInvalido(string nomeInvalido)
        {
            Assert.Throws<ArgumentException>(() => CursoBuilder.CursoNovo().CursoComNome(nomeInvalido).ConstruirCurso()).WithMessage("Nome Inválido!");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(0.9)]
        [InlineData(-2)]
        public void CargaHorariaNaoPodeSerMenorQue1(double cargaHorariaInvalida)
        {
            Assert.Throws<ArgumentException>(() => CursoBuilder.CursoNovo().CursoComCargaHoraria(cargaHorariaInvalida).ConstruirCurso()).WithMessage("Carga Horária Inválida!");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-2)]
        public void ValorDoCursoDeveSerMaiorQue0(double valorInvalido)
        {
            Assert.Throws<ArgumentException>(() => CursoBuilder.CursoNovo().CursoComValor(valorInvalido).ConstruirCurso()).WithMessage("Valor Inválido!");
        }
    }
}