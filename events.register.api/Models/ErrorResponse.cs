using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;

namespace events.register.api.Models
{
    public class ErrorResponse
    {
        public ErrorResponse() { }

        public ErrorResponse(string erro)
        {
            Code = 400;
            Message = "Não foi possível adicionar um novo cadastro";
            InnerError = null;
            Details = new string[] { erro };
        }

        public int Code { get; set; }
        public string Message { get; set; }
        public ErrorResponse InnerError { get; set; }
        public string[] Details { get; set; }

        public static ErrorResponse From(Exception ex)
        {
            if (ex == null)
            {
                return null;
            }
            return new ErrorResponse
            {
                Code = ex.HResult,
                Message = ex.Message,
                InnerError = ErrorResponse.From(ex.InnerException)
            };
        }

        public static object FromModelState(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(m => m.Errors);
            return new ErrorResponse
            {
                Code = 100,
                Message = "Houve um erro(s) o envio da Requisição",
                Details = erros.Select(e => e.ErrorMessage).ToArray(),
                InnerError = null,
            };
        }
    }
}
