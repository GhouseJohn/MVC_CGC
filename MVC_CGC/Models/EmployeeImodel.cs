using MVC_DLL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace MVC_CGC.Models
{
    public class EmployeeImodel : System.Web.Mvc.IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {
            HttpContextBase Objcontext = controllerContext.HttpContext;
            string Name = Objcontext.Request.Form["saveEmployee.EmpName"];
            string Password = Objcontext.Request.Form["saveEmployee.Psw"];
            string conPsw = Objcontext.Request.Form["saveEmployee.ConfirmPsw"];
            int CntId = Convert.ToInt32(Objcontext.Request.Form["saveEmployee.Cnt_Id"]);
            int StsId = Convert.ToInt32(Objcontext.Request.Form["saveEmployee.Sts_Id"]);


            MasterTable ObjEmployee = new MasterTable()
            {
                //EmpName = Name,
                //Psw = Password,
                //ConfirmPsw = conPsw,
                //Cnt_Id = CntId,
                //Sts_Id = StsId
            };
            return ObjEmployee;
        }
    }
   
}
