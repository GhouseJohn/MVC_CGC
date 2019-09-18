using MVC_DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DLL.VIewModel
{
    public class HybridClass
    {
        public MasterTable _MasterTable { get; set; }
        public List<MasterTable> GetMasterData { get; set; }
        public List<Country> GetCountryData { get; set; }
      //      public List<SelectListItem> SelectListItem { get; set; }
    }
}