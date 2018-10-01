using TestCourseWithDDD.Domain.Entities;

namespace TestCourseWithDDD.Domain.Interfaces.Repositories
{
    public interface IRepositoryCurso : IRepository<Curso>
    {
        Curso ObterPorNome(string cursoDtoNome);
    }
}
