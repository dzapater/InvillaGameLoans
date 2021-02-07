using Invilla.Services.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace InvillaGamesLoan.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class InvillaSecurityAttribute : Attribute, IActionFilter
    {

        public InvillaSecurityAttribute()
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {

            bool allowAnonymous = context.Filters
                .Where(filter => filter.GetType() == typeof(AllowAnonymousFilter))
                .Count() > 0;

            if (!allowAnonymous)
            {

                var token = JwtTokenUtils.GetToken(context.HttpContext);

                bool isValidToken = JwtTokenUtils.IsValidToken(token);

                if (!isValidToken)
                {
                    context.HttpContext.Response.StatusCode = 401;
                    context.Result = new EmptyResult();
                    return;
                }

                if (context.HttpContext.Response.StatusCode == 401)
                {
                    context.Result = new EmptyResult();
                    return;
                }

            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

    }
}
