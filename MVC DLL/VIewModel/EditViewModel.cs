using MVC_DLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DLL.VIewModel
{
    public class EditViewModel
    {
        public MasterTable _MasterTable { get; set; }
        public List<MasterTable> _ListMasterTable { get; set; }
        public List<Country> _EditCountryData { get; set; }
        public List<State> _EditStateData { get; set; }
        public List<City> _EditCityData { get; set; }


    }
}