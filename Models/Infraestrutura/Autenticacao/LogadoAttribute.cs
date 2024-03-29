using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace admin_cms.Models.Infraestrutura.Autenticacao
{
    public class LogadoAttribute : ActionFilterAttribute
    {
        // public override void OnResultExecuting(ResultExecutingContext filterContext)
        // {
        //   if( string.IsNullOrEmpty(filterContext.HttpContext.Session.GetString("usuario")) ){
        //     filterContext.HttpContext.Response.Redirect("/");
        //     return;
        //   }
        //   base.OnResultExecuting(filterContext);
        // }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (string.IsNullOrEmpty(filterContext.HttpContext.Request.Cookies["adm_cms"]))
            {
                filterContext.HttpContext.Response.Redirect("/login");
                return;
            }
            base.OnActionExecuting(filterContext);
        }

    }
}