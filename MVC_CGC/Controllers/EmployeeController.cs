using MVC_CGC.DbConnection;
using MVC_CGC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CGC.Controllers
{
    [RoutePrefix("api/Employee")]
    public class EmployeeController : Controller
    {
        AdoContext _db = new AdoContext();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("SaveData")]
        public ActionResult SaveData(FeedbackForm1 _feedBack)
        {
            var _file = _feedBack.ProjectInformation;
            var _fileName = _file.FileName;
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(_file.InputStream))
            {
                bytes = br.ReadBytes(_file.ContentLength);
            }
            FeedbackForm forms = _feedBack.fs;
            //var _myData = bytes;
            forms.ProjectInformation = bytes;
            forms.FileName = _fileName;
            _db.FeedbackForm.Add(forms);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}