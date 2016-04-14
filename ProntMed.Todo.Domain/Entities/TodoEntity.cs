using System;

namespace ProntMed.Todo.Domain.Entities
{
    public sealed class TodoEntity : Base.BaseEntity
    {
        public String Titulo { get; set; }

        public String Descricao { get; set; }

        public DateTime Data { get; set; }

        public String Status { get; set; }
    }
}
