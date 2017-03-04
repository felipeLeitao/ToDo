using Ninject;
using ProntMed.Todo.DataAccess.Context;
using ProntMed.Todo.Domain.Interfaces.UnityOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntMed.Todo.DataAccess.UnityOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DateTime dataInicio = DateTime.Now;

        private DbContext _context;

        private DbContextTransaction _transaction;

        public UnitOfWork(DbContext context_)
        {
            _context = context_;
        }

        public void Begin()
        {
           _transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void RollBack()
        {
            _context.Dispose();
        }
    }
}
