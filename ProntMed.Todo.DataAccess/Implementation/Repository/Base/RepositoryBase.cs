using ProntMed.Todo.Domain.Entities.Base;
using ProntMed.Todo.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ProntMed.Todo.DataAccess.Implementation.Repository.Base
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        private readonly DbContext _conexao;

        private readonly DbSet<T> _tabela;

        public RepositoryBase(DbContext conexao_)
        {
            _conexao = conexao_;
            _tabela = _conexao.Set<T>();
        }
        public void CreateAsync(T obj_)
        {
            _tabela.Add(obj_);
            _conexao.SaveChanges();
        }

        public IList<T> GetAll()
        {
            return _tabela.ToList();
        }

        public void UpdateAsync(T obj_)
        {
            _conexao.Entry(obj_).State = EntityState.Modified;
        }

        public void DeleteAsync(T obj_)
        {
            _tabela.Remove(obj_);
        }

        public IList<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> filtro_)
        {
            return _tabela.Where(filtro_).ToList();
        }
    }
}
