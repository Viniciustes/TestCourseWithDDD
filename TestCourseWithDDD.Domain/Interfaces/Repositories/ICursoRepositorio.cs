using TestCourseWithDDD.Domain.Entities;

namespace TestCourseWithDDD.Domain.Interfaces.Repositories
{
    public interface ICursoRepositorio
    {
        void Listar();
        void Gravar(Curso curso);
        void Alterar(Curso curso);
        void Apagar(int Id);
        Curso ObterPorNome(string cursoDtoNome);
    }
}
