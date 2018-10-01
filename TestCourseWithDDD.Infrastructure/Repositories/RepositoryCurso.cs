using TestCourseWithDDD.Domain.Entities;
using TestCourseWithDDD.Domain.Interfaces.Repositories;
using TestCourseWithDDD.Infrastructure.Contexts;

namespace TestCourseWithDDD.Infrastructure.Repositories
{
    public class RepositoryCurso : Repository<Curso>, IRepositoryCurso
    {
        public RepositoryCurso(ApplicationDbContext context) : base(context)
        {
        }

        public Curso ObterPorNome(string cursoDtoNome)
        {
            throw new System.NotImplementedException();
        }
    }
}
