﻿using ProntMed.Todo.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProntMed.Todo.Domain.Interfaces.Repositories.Base
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        Task CreateAsync(T obj_);

        IList<T> GetAll();

        Task UpdateAsync(T obj_);

        Task DeleteAsync(T obj_);

        IList<T> Get(Expression<Func<T, Boolean>> filtro_);
    }
}
