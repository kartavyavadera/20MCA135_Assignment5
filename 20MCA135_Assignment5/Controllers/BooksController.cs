using _20MCA135_Assignment5.Filters;
using _20MCA135_Assignment5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _20MCA135_Assignment5.Controllers
{
    
    public class BooksController : ApiController
    {
        DBBookEntities bdb = new DBBookEntities();

        [HttpPost]
        public String InsertBook(tblBook book)
        {
            try
            {
                bdb.tblBooks.Add(book);
                bdb.SaveChanges();
                return "Data Added Successfully";
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting  
                        // the current instance as InnerException  
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        [HttpGet]
        public List<tblBook> GetBooks()
        {
            List<tblBook> bdata = bdb.tblBooks.ToList();
            if (bdata.Count > 0)
            {
                return bdata;
            }
            return bdata;
        }

        [HttpGet]
        public tblBook GetBookData(int bid)
        {
            tblBook bdata = bdb.tblBooks.Find(bid);
            return bdata;

        }
        
        [HttpPatch]
        public tblBook UpdateStudentData(int bid, tblBook b)
        {
            tblBook bdata = bdb.tblBooks.Find(bid);
            bdata.bname = b.bname;
            bdata.author =b.author;
            bdata.pub = b.pub;
            bdata.sub = b.sub;
            bdb.SaveChanges();
            return bdata;

        }

        [HttpDelete]
        public String DeleteBookData(int bid)
        {
            tblBook bdata = bdb.tblBooks.Find(bid);
            bdb.tblBooks.Remove(bdata);
            bdb.SaveChanges();
            return "Data deleted Successfully";

        }
    }
}
