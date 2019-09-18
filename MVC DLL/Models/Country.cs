using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace MVC_DLL.Models
{
    public class Country
    {
        [Key]
        public int Cnt_Id { get; set; }
        public string Cnt_Name { get; set; }
    }
}