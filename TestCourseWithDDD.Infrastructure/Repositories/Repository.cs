using System.Collections.Generic;
using System.Linq;
using TestCourseWithDDD.Domain.Entities;
using TestCourseWithDDD.Domain.Interfaces.Repositories;
using TestCourseWithDDD.Infrastructure.Contexts;

namespace TestCourseWithDDD.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly ApplicationDbContext Context;

        public Repository(ApplicationDbContext context)
        {
            Context = context;
        }

        public void Adicionar(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public TEntity ObterPorId(int id)
        {
            return Context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
        }

        public IList<TEntity> Listar()
        {
            return Context.Set<TEntity>().ToList();
        }

        public void Alterar(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}