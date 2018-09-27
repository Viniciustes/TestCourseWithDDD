using Bogus;
using Moq;
using System;
using TestCourseWithDDD.Domain.Entities;
using TestCourseWithDDD.Domain.Enums;
using TestCourseWithDDD.Domain.Interfaces.Repositories;
using TestCourseWithDDD.Test.Exceptions;
using Xunit;

namespace TestCourseWithDDD.Test.CursoTests
{
    public class CursoServiceTest
    {

        private CursoDto _cursoDto;
        private Mock<ICursoRepositorio> _cursoRepositorioMock;
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

            _cursoRepositorioMock = new Mock<ICursoRepositorio>();

            _cursoService = new CursoService(_cursoRepositorioMock.Object);
        }

        [Fact]
        public void DeveAdicionarCurso()
        {
            _cursoService.Gravar(_cursoDto);

            _cursoRepositorioMock.Verify(x => x.Gravar(It.Is<Curso>(
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
    }

    public class CursoService
    {
        private readonly ICursoRepositorio _cursoRepository;

        public CursoService(ICursoRepositorio cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public void Gravar(CursoDto cursoDto)
        {
            var publicoAlvo = ValidarEnumPublicoAlvo(cursoDto);

            var curso = new Curso(cursoDto.Nome, publicoAlvo, cursoDto.Valor, cursoDto.Descricao, cursoDto.CargaHoraria, cursoDto.DataCadastro, cursoDto.Ativo);

            _cursoRepository.Gravar(curso);
        }

        public void Alterar(CursoDto cursoDto)
        {
            var publicoAlvo = ValidarEnumPublicoAlvo(cursoDto);

            var curso = new Curso(cursoDto.Nome, publicoAlvo, cursoDto.Valor, cursoDto.Descricao, cursoDto.CargaHoraria, cursoDto.DataCadastro, cursoDto.Ativo);

            _cursoRepository.Alterar(curso);
        }

        private static PublicoAlvo ValidarEnumPublicoAlvo(CursoDto cursoDto)
        {
            Enum.TryParse(typeof(PublicoAlvo), cursoDto.PublicoAlvo, out var publicoAlvo);

            if (publicoAlvo == null)
                throw new ArgumentException("Público alvo inválido!");
            return (PublicoAlvo)publicoAlvo;
        }
    }

    public class CursoDto
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
        public string PublicoAlvo { get; set; }
        public DateTime DataCadastro { get; set; }
        public double CargaHoraria { get; set; }
        public bool Ativo { get; set; }
    }
}
