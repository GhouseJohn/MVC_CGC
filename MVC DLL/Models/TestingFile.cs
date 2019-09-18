using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MVC_DLL.Models.CustomValidators;

namespace MVC_DLL.Models
{
    public class TestingFile
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public bool Married { get; set; }
        
        [RequiredIf("Married", true, ErrorMessage = "Wife Name is required"),
         RangeIf(5,9, "Married", true, ErrorMessage = "name range is 5 - ")]
        public string WifeName { get; set; }

        [RequiredIf("Married",true, ErrorMessage = "Wife_doB Name is required")]
        public string Wife_dOB { get; set; }
        //[RequiredIf("Married",true, ErrorMessage = "Wife_doB Name is required",minvalue ="6")]
        //public int MyProperty { get; set; }
    }
}