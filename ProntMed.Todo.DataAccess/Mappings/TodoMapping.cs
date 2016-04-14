using ProntMed.Todo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProntMed.Todo.DataAccess.Mappings
{
    public class TodoMapping : Base.BaseMapping<TodoEntity>
    {
        public TodoMapping()
        {
            this.ToTable("TB_TODO");
            this.Property(t => t.Codigo).HasColumnName("idTodo").IsRequired();
            this.Property(t => t.Data).HasColumnName("dtCadastro").IsRequired();
            this.Property(t => t.Descricao).HasColumnName("dsTodo").IsRequired();
            this.Property(t => t.Titulo).HasColumnName("dsTitulo").IsRequired();
            this.Property(t => t.Status).HasColumnName("dsStatus").IsRequired();
        }
    }
}
