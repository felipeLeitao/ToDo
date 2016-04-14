using ProntMed.Todo.Domain.Entities;
using ProntMed.Todo.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntMed.Todo.DataAccess.Implementation.Repository
{
    public class TodoRepository : Base.RepositoryBase<TodoEntity> , ITodoRepository
    {
        public TodoRepository(DbContext conexao_) : base(conexao_)
        {

        }
    }
}
