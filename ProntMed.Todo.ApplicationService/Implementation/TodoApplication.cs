
using ProntMed.Todo.ApplicationService.Interfaces;
using ProntMed.Todo.Domain.Entities;
using ProntMed.Todo.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProntMed.Todo.ApplicationService.Implementation
{
    public sealed class TodoApplication : ITodoApplication
    {
        private readonly ITodoRepository _todoRepository;

        public TodoApplication(ITodoRepository todoRepository_)
        {
            _todoRepository = todoRepository_;
        }
        public async Task CreateAsync(TodoEntity obj_)
        {
           await _todoRepository.CreateAsync(obj_);
        }

        public IList<TodoEntity> GetAll()
        {
            return _todoRepository.GetAll();
        }

        public async Task UpdateAsync(TodoEntity obj_)
        {
           await _todoRepository.UpdateAsync(obj_);
        }

        public async Task DeleteAsync(TodoEntity obj_)
        {
           await _todoRepository.DeleteAsync(obj_);
        }

        public IList<TodoEntity> Get(Expression<System.Func<TodoEntity, bool>> filtro_)
        {
            return _todoRepository.Get(filtro_);
        }
    }
}
