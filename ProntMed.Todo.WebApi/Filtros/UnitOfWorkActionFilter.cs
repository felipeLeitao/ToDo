using ProntMed.Todo.Domain.Interfaces.UnityOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ProntMed.Todo.WebApi.Filtros
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class UnitOfWorkActionFilter : ActionFilterAttribute
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            _unitOfWork = (IUnitOfWork) actionContext.Request.GetDependencyScope().GetService(typeof(IUnitOfWork));
            _unitOfWork.Begin();

            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            _unitOfWork = actionExecutedContext.Request.GetDependencyScope().GetService(typeof(IUnitOfWork)) as IUnitOfWork;
            if (actionExecutedContext.Exception == null)
            {
                // commit if no exceptions
                _unitOfWork.Commit();
            }
            else
            {
                // rollback if exception
                _unitOfWork.RollBack();
            }

            base.OnActionExecuted(actionExecutedContext);
        }
    }
}