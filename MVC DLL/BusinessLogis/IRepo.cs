using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_DLL.Models;

namespace MVC_DLL.BusinessLogis
{
   public interface IRepo
    {
        List<Country> GetCountry();
        List<State> GetStateById(int cntId);
        List<City> GetCityById(int StateId);
        int InsertData(MasterTable _master);
        List<MasterTable> GetMasterTableData();
        List<MasterTable> GetMasterById(int Id);
        List<State> GetStateNameById(int cntId);
        List<City> GetCity_Name_ById(int StateId);

    }
}
