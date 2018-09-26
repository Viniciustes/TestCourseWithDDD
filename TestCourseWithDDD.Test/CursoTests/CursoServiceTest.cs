using Moq;
using System;
using TestCourseWithDDD.Domain.Entities;
using TestCourseWithDDD.Domain.Enums;
using Xunit;

namespace TestCourseWithDDD.Test.CursoTests
{
    public class CursoServiceTest
    {

        [Fact]
        public void DeveAdicionarCurso()
        {
            var cursoDto = new CursoDto
            {
                Nome = "Curso A",
                Valor = 600,
                Descricao = "Curso descição",
                PublicoAlvoId = 1,
                DataCadastro = DateTime.Now,
                CargaHoraria = 40,
                Ativo = true
            };

            var cursoRepositorioMock = new Mock<ICursoRepositorio>();

            var cursoService = new CursoService(cursoRepositorioMock.Object);

            cursoService.Gravar(cursoDto);

            cursoRepositorioMock.Verify(x => x.Gravar(It.IsAny<Curso>()));
        }
    }

    public interface ICursoRepositorio
    {
        void Listar();
        void Gravar(Curso curso);
        void Alterar(Curso curso);
        void Apagar(int Id);
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
            var curso = new Curso(cursoDto.Nome, PublicoAlvo.Estudante, cursoDto.Valor, cursoDto.Descricao, cursoDto.CargaHoraria, cursoDto.DataCadastro, cursoDto.Ativo);

            _cursoRepository.Gravar(curso);
        }
    }

    public class CursoDto
    {
        public string Nome { get; set; }
        public int Valor { get; set; }
        public string Descricao { get; set; }
        public int PublicoAlvoId { get; set; }
        public DateTime DataCadastro { get; set; }
        public int CargaHoraria { get; set; }
        public bool Ativo { get; set; }
    }
}
