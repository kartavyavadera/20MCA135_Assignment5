using _20MCA135_Assignment5.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace _20MCA135_Assignment5.Controllers
{
    public class StudentController : ApiController
    {
        StudentdbEntities sdb = new StudentdbEntities();

        [HttpPost]
        public String PostStudent(tblStudent student)
        {
            
                sdb.tblStudents.Add(student);
            String data = "Post Student Data on" + DateTime.Now.ToString();

                sdb.SaveChanges();
                File.AppendAllText(HttpContext.Current.Server.MapPath("~/Log.txt"), data + "\n");

                return "Data Added Successfully";
         
        }

        [HttpGet]
        public List<tblStudent>GetStudents()
        {
            List<tblStudent> sdata = sdb.tblStudents.ToList();
            if(sdata.Count>0)
            {
                return sdata;
            }
            return sdata;
        }

        [HttpGet]
        public tblStudent GetStudentData(int sid)
        {
           tblStudent sdata = sdb.tblStudents.Find(sid);           
                return sdata;
         
        }
        [HttpPatch]
        public tblStudent UpdateStudentData(int sid,tblStudent s)
        {
            tblStudent sdata = sdb.tblStudents.Find(sid);
            sdata.sname = s.sname;
            sdata.scity = s.scity;
            sdata.sdegree = s.sdegree;
            sdata.gender = s.gender;
            sdb.SaveChanges();
            return sdata;

        }

        [HttpDelete]
        public String DeleteStudentData(int sid)
        {
            tblStudent sdata = sdb.tblStudents.Find(sid);
            sdb.tblStudents.Remove(sdata);         
            sdb.SaveChanges();
            return "Data deleted Successfully";

        }

    }
}
