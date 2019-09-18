using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_CGC.Models
{
    public class FeedbackForm1
    {      
        public FeedbackForm fs { get; set; }
        public HttpPostedFileBase ProjectInformation { get; set; }
    }
    public class FeedbackForm
    {
        [Key]
        public int Fedd_Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string FileName { get; set; }
        public byte[] ProjectInformation { get; set; }
    }
}