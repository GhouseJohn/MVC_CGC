using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_DLL.Models
{
    public class MasterTable
    {
        [Key]
        public int Id { get; set; }
        public string Master_Token { get; set; }
        [Required(ErrorMessage ="Please Enter Master_Name")]
        public string Master_Name { get; set; }
        [Required(ErrorMessage = "Please Enter You Master_Email")]
        public string Master_Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password")]
        public string PassWord { get; set; }
        [Required(ErrorMessage = "Please Enter Your ImagId")]
        public int ImageId { get; set; }
        [Required(ErrorMessage = "Field is required.")]
        public int ContryId { get; set; }
        [Required(ErrorMessage = "Please Enter Your StateId")]
        public int StateId { get; set; }
        [Required(ErrorMessage = "Please Enter Your CityId")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "Please Enter Country Name")]
        public List<SelectListItem> statelist { get; set; }

        public HttpPostedFile HelloFile { get; set; }

    }
}