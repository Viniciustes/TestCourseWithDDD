using Bogus;
using Moq;
using System;
using TestCourseWithDDD.Domain.Dtos;
using TestCourseWithDDD.Domain.Entities;
using TestCourseWithDDD.Domain.Enums;
using TestCourseWithDDD.Domain.Interfaces.Repositories;
using TestCourseWithDDD.Domain.Services;
using TestCourseWithDDD.Test.Builders;
using TestCourseWithDDD.Test.Exceptions;
using Xunit;

namespace TestCourseWithDDD.Test.CursoTests
{
    public class CursoServiceTest
    {
        private CursoDto _cursoDto;
        private Mock<IRepositoryCurso> _cursoRepositorioMock;
        private CursoService _cursoService;

        public CursoServiceTest()
        {
            var faker = new Faker();

            _cursoDto = new CursoDto
            {
                Nome = faker.Random.Words(),
                Valor = faker.Random.Double(100, 5000),
                Descricao = faker.Lorem.Paragraph(),
                PublicoAlvo = faker.Random.Enum<PublicoAlvo>().ToString(),
                DataCadastro = DateTime.Now,
                CargaHoraria = faker.Random.Double(1, 100),
                Ativo = faker.Random.Bool()
            };

            _cursoRepositorioMock = new Mock<IRepositoryCurso>();

            _cursoService = new CursoService(_cursoRepositorioMock.Object);
        }

        [Fact]
        public void DeveAdicionarCurso()
        {
            _cursoService.Gravar(_cursoDto);

            _cursoRepositorioMock.Verify(x => x.Adicionar(It.Is<Curso>(
                y => y.Nome == _cursoDto.Nome &&
                y.Valor == _cursoDto.Valor &&
                y.Descricao == _cursoDto.Descricao &&
                y.DataCadastro == _cursoDto.DataCadastro &&
                y.CargaHoraria == _cursoDto.CargaHoraria &&
                y.Ativo == _cursoDto.Ativo
                )));
        }

        [Fact]
        public void DeveAlterarCurso()
        {
            _cursoService.Alterar(_cursoDto);

            _cursoRepositorioMock.Verify(x => x.Alterar(It.Is<Curso>(
                y => y.Nome == _cursoDto.Nome &&
                y.Valor == _cursoDto.Valor &&
                y.Descricao == _cursoDto.Descricao &&
                y.DataCadastro == _cursoDto.DataCadastro &&
                y.CargaHoraria == _cursoDto.CargaHoraria &&
                y.Ativo == _cursoDto.Ativo
                )));
        }

        [Fact]
        public void PublicoAlvoNaoPodeSerInvalido()
        {
            var publicoAlvoInvalido = "PublicoAlvoInvalido";
            _cursoDto.PublicoAlvo = publicoAlvoInvalido;

            Assert.Throws<ArgumentException>(() => _cursoService.Gravar(_cursoDto)).WithMessage("Público alvo inválido!");
        }

        [Fact]
        public void CursoNaoPodeTerMesmoNomeExistente()
        {
            var curso = CursoBuilder.CursoNovo().CursoComNome(_cursoDto.Nome).ConstruirCurso();
            _cursoRepositorioMock.Setup(x => x.ObterPorNome(_cursoDto.Nome)).Returns(curso);

            Assert.Throws<ArgumentException>(() => _cursoService.Gravar(_cursoDto)).WithMessage("Nome do curso já existe!");
        }
    }
}
