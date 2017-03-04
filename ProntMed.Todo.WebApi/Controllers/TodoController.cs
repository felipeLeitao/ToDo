using ProntMed.Todo.ApplicationService.Interfaces;
using ProntMed.Todo.Domain.Entities;
using ProntMed.Todo.WebApi.DTO;
using ProntMed.Todo.WebApi.Filtros;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ProntMed.Todo.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [UnitOfWorkActionFilter]
    public class TodoController : ApiController
    {
        private readonly ITodoApplication _todoApplication;
        public TodoController(ITodoApplication todoApplication_)
        {
            _todoApplication = todoApplication_;
        }

        [HttpGet]
        public HttpResponseMessage Listar()
        {
            try
            {
                var retorno = _todoApplication.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, retorno);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Oops, Falha ao listar tarefas.");
            }
        }

        [HttpGet]
        public HttpResponseMessage GetByID(int id)
        {
            try
            {
                var retorno = _todoApplication.Get(x => x.Codigo == id).Single();
                return Request.CreateResponse(HttpStatusCode.OK, retorno);
            }
            catch (InvalidOperationException)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Oops, Item não encontrado.");
            }

            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Oops, Falha ao pesquisar item.");
            }
        }

        [HttpPost]
        public HttpResponseMessage Cadastrar(Tarefa tarefa)
        {
            try
            {
                TodoEntity todo = new TodoEntity()
                {
                    Data = DateTime.ParseExact(tarefa.Data, "dd/MM/yyyy", null),
                    Descricao = tarefa.Descricao,
                    Status = tarefa.Status,
                    Titulo = tarefa.Titulo
                };


                _todoApplication.CreateAsync(todo);
                return Request.CreateResponse(HttpStatusCode.OK, "Tarefa cadastrada com sucesso.");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Oops, Falha ao cadastrar tarefa.");
            }
        }

        [HttpPost]
        public HttpResponseMessage Alterar(TodoEntity obj_)
        {
            try
            {
                var tarefa = _todoApplication.Get(x => x.Codigo == obj_.Codigo).Single();

                tarefa.Data = obj_.Data;
                tarefa.Descricao = obj_.Descricao;
                tarefa.Titulo = obj_.Titulo;
                tarefa.Status = obj_.Status;

                _todoApplication.UpdateAsync(tarefa);

                return Request.CreateResponse(HttpStatusCode.OK, "Tarefa alterada com sucesso.");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Oops, Falha ao alterar tarefa.");
            }
        }

        [HttpGet]
        public HttpResponseMessage Remover(int id)
        {
            try
            {
                var obj = _todoApplication.Get(x => x.Codigo == id).Single();
                _todoApplication.DeleteAsync(obj);
                return Request.CreateResponse(HttpStatusCode.OK, "Tarefa removida com sucesso.");
            }

            catch (InvalidOperationException)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Esta tarefa não existe.");
            }

            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Oops, Falha ao remover tarefa");
            }
        }

        [HttpGet]
        public HttpResponseMessage Pesquisar(string descricao)
        {
            try
            {
                var retorno = _todoApplication.Get(x => x.Descricao.Contains(descricao));


                if (retorno.Count == 0)
                    return Request.CreateResponse(HttpStatusCode.OK, "Nenhum item encontrado.");
                
                return Request.CreateResponse(HttpStatusCode.OK, retorno);
            }

            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Oops, Falha ao pesquisar itens");
            }
        }
    }
}
