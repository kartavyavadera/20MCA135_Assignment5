using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace _20MCA135_Assignment5.Filters
{
    public class ExceptionFilter:ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnException(actionExecutedContext);

            if(actionExecutedContext.Exception is DbUpdateException)
            {
                HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
                response.Content = new StringContent("Insufficent data");
                response.ReasonPhrase = "Not Null field is empty";


            }
        
        }



    }
}