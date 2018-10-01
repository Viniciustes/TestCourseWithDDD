using System;
using TestCourseWithDDD.Domain.Dtos;
using TestCourseWithDDD.Domain.Entities;
using TestCourseWithDDD.Domain.Enums;
using TestCourseWithDDD.Domain.Interfaces.Repositories;

namespace TestCourseWithDDD.Domain.Services
{
    public class CursoService
    {
        private readonly IRepositoryCurso _cursoRepository;

        public CursoService(IRepositoryCurso cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public void Gravar(CursoDto cursoDto)
        {
            var publicoAlvo = ValidarEnumPublicoAlvo(cursoDto);

            ValidarNomeCursoDuplicado(cursoDto);

            var curso = new Curso(cursoDto.Nome, publicoAlvo, cursoDto.Valor, cursoDto.Descricao, cursoDto.CargaHoraria, cursoDto.DataCadastro, cursoDto.Ativo);

            _cursoRepository.Adicionar(curso);
        }

        public void Alterar(CursoDto cursoDto)
        {
            var publicoAlvo = ValidarEnumPublicoAlvo(cursoDto);

            ValidarNomeCursoDuplicado(cursoDto);

            var curso = new Curso(cursoDto.Nome, publicoAlvo, cursoDto.Valor, cursoDto.Descricao, cursoDto.CargaHoraria, cursoDto.DataCadastro, cursoDto.Ativo);

            _cursoRepository.Alterar(curso);
        }

        private void ValidarNomeCursoDuplicado(CursoDto cursoDto)
        {
            var cursoNome = _cursoRepository.ObterPorNome(cursoDto.Nome);

            if (cursoNome != null)
                throw new ArgumentException("Nome do curso já existe!");
        }

        private static PublicoAlvo ValidarEnumPublicoAlvo(CursoDto cursoDto)
        {
            Enum.TryParse(typeof(PublicoAlvo), cursoDto.PublicoAlvo, out var publicoAlvo);

            if (publicoAlvo == null)
                throw new ArgumentException("Público alvo inválido!");

            return (PublicoAlvo)publicoAlvo;
        }
    }
}
