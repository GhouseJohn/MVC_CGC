using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;



namespace MVC_DLL.Models
{
    public class State
    {
        [Key]
        public int Sts_Id { get; set; }
        public string Sts_Name { get; set; }
        public int Sts_Cnt_Id { get; set; }
    }
}