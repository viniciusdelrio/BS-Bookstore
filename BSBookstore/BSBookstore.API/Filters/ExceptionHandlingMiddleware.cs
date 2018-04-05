using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BSBookstore.API
{
    /// <summary>
    /// Tratador de exceções para serem enviadas ao front
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        #region Attributes

        private readonly RequestDelegate _next;

        #endregion

        #region Constructors

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        #endregion

        #region Methods

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        /// <summary>
        /// Trata as exceções
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            //Valor default do código de erro
            var code = HttpStatusCode.InternalServerError;

            //Tratando mensagens do FluentValidation
            if (exception is ValidationException)
            {
                code = HttpStatusCode.ExpectationFailed;
            }

            var result = JsonConvert.SerializeObject(new { error = exception.Message });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }

        #endregion
    }
}
