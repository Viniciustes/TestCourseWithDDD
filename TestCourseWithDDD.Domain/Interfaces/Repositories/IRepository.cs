using System.Collections.Generic;

namespace TestCourseWithDDD.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity>
    {
        void Adicionar(TEntity entity);

        IList<TEntity> Listar();

        TEntity ObterPorId(int id);
    }
}
