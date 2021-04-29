using _20MCA135_Assignment5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace _20MCA135_Assignment5.Filters
{
    public class Auth:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
    {
        base.OnAuthorization(actionContext);


        if (actionContext.Request.Headers.Authorization == null)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage(HttpStatusCode.Forbidden);
            httpResponse.Content = new StringContent("Authorization Data is missing!!!");
            //httpResponse.ReasonPhrase = "No Authorization!!";
            actionContext.Response = httpResponse;
        }
        else
        {
            String encodedData = actionContext.Request.Headers.Authorization.Parameter;
            String decodeData = Encoding.UTF8.GetString(Convert.FromBase64String(encodedData));
            String[] userdata = decodeData.Split(':');

            //int uid = Convert.ToInt32(userdata[0]);
            String uname =userdata[0];
            String pass = userdata[1];

                 StudentdbEntities db = new StudentdbEntities();

                User u1 = db.Users.Where(u => u.u_name == uname && u.u_pass.Equals(pass)).FirstOrDefault();
            if (u1 != null)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(u1.u_name), null);
            }
            else
            {
                HttpResponseMessage httpResponse = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                httpResponse.Content = new StringContent("Authorization Data is invalid !!!");
                httpResponse.ReasonPhrase = "No Authorization!!";
                actionContext.Response = httpResponse;
            }

        }
    }
}
   
}