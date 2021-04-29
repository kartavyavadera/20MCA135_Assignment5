
using _20MCA135_Assignment5.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _20MCA135_Assignment5.Controllers
{
    public class InterestController : ApiController
    {
       
        public int GetSI(int p,int r,int n)
        {
           if(p<0)
            {
                throw new IllegalArgumentException();
            }


            int si = (p * r * n )/ 100;

            return si;

        }
    }
}
