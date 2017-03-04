using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProntMed.Todo.WebApi.DTO
{
    public class Tarefa
    {
        public int Id { get; set; }

        public String Titulo { get; set; }

        public String Descricao { get; set; }

        public String Data { get; set; }

        public String Status { get; set; }
    }
}