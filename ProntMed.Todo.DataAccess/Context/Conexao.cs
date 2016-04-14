using ProntMed.Todo.DataAccess.Mappings;
using ProntMed.Todo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntMed.Todo.DataAccess.Context
{
    public class Conexao : DbContext
    {
        public Conexao() : base("Conexao")
        {

        }

        public DbSet<TodoEntity> Todo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TodoMapping());
        }
    }


}
