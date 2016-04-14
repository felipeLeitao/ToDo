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
        public async Task CreateAsync(T obj_)
        {
            _tabela.Add(obj_);
            await _conexao.SaveChangesAsync();
        }

        public IList<T> GetAll()
        {
            return _tabela.ToList();
        }

        public async Task UpdateAsync(T obj_)
        {
            _conexao.Entry(obj_).State = EntityState.Modified;
           await _conexao.SaveChangesAsync();
        }

        public async Task DeleteAsync(T obj_)
        {
            _tabela.Remove(obj_);
            await _conexao.SaveChangesAsync();
        }

        public IList<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> filtro_)
        {
            return _tabela.Where(filtro_).ToList();
        }
    }
}
