using MVC_DLL.AES256Encryption;
using MVC_DLL.BusinessLogis;
using MVC_DLL.Models;
using MVC_DLL.VIewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CGC.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        // GET: Home
        //IRepo _ObjRepo { get; set; }
        private readonly IRepo _ObjRepo;
        public HomeController()
        {
            _ObjRepo = new Repo();
        }



        [HttpGet]
        [Route("Index")]
        public ActionResult Index(HybridClass _hybrid)
        {
            HybridClass _objHybrid = new HybridClass();
            var _MasterData = _ObjRepo.GetMasterTableData();
            var _CountryData = _ObjRepo.GetCountry().ToList();
            _objHybrid.GetMasterData = _MasterData;
            var _CountryListData = _ObjRepo.GetCountry();
            _objHybrid.GetCountryData = _CountryListData;
            //ViewBag.countrlist = _CountryData.Select(x => new SelectListItem
            //{
            //    Text = x.Cnt_Name.ToString(),
            //    Value = x.Cnt_Id.ToString()
            //});
            return View("Index", _objHybrid);
        }

        [HttpGet]
        [Route("StateList/{_CntId}")]
        public ActionResult StateList(int _CntId)
        {
            var _CountryData = _ObjRepo.GetStateById(_CntId);
            return View(_CountryData);
        }
        [HttpGet]
        [Route("Getstatelist/{countryid}")]
        public JsonResult Getstatelist(string countryid)
        {
            MasterTable mastertable = new MasterTable();
            var statelist = _ObjRepo.GetStateById(Convert.ToInt32(countryid)).ToList();
            mastertable.statelist = statelist.Select(x => new SelectListItem
            {
                Text = x.Sts_Name.ToString(),
                Value = x.Sts_Id.ToString()
            }).ToList();
            return Json(mastertable.statelist, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [Route("CityList/{_State}")]
        public ActionResult CityList(int _State)
        {
            var _CountryData = _ObjRepo.GetCityById(_State);
            return Json(_CountryData, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        [Route("GetMasterData")]
        public ActionResult GetMasterData()
        {
            var _CountryData = _ObjRepo.GetMasterTableData();
            return View(_CountryData);
        }

        [HttpPost]
        [Route("InsertMasterData")]
        //  public ActionResult InsertMasterData(MasterTable _Master)
        public ActionResult InsertMasterData(HybridClass _obj)

        {

            //string _FolderPath = "~/FileFolder/UserRegFiles";
            //string _fileName = _obj.ProjectInformation.FileName;
            //string _fileExt = System.IO.Path.GetExtension(_fileName);
            //bool exists = System.IO.Directory.Exists(Server.MapPath(_FolderPath));
            //if (!exists)
            //    System.IO.Directory.CreateDirectory(Server.MapPath(_FolderPath));
            // string _folderPath= DateTime.Now.ToString("yyyyMMddHHmmssfff") + "_" + Guid.NewGuid().ToString("N")+ _fileExt;
            //var path = System.IO.Path.Combine(Server.MapPath(_FolderPath), _folderPath);

          //  _obj.ProjectInformation.SaveAs(path);
            MasterTable _objmaster = new MasterTable();
            _objmaster.Master_Email = Request.Form["_MasterTable.Master_Email"];
            _objmaster.PassWord = Request.Form["_MasterTable.PassWord"];
            _objmaster.Master_Name = Request.Form["_MasterTable.Master_Name"];
            //  _objmaster.ImageId = Convert.ToInt16(Request.Form["_MasterTable.ImageId"]);
            _objmaster.ImageId = 1;

            _objmaster.ContryId = Convert.ToInt16(Request.Form["_MasterTable.ContryId"]);
            _objmaster.StateId = Convert.ToInt16(Request.Form["_MasterTable.StateId"]);
            _objmaster.CityId = Convert.ToInt16(Request.Form["_MasterTable.CityId"]);
            if (ModelState.IsValid)
            {
                int res = _ObjRepo.InsertData(_objmaster);
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        TestingLogic _ObjTest = new TestingLogic();

        public ActionResult TestIndex()
        {
            return View();
        }


        [HttpPost]
        [Route("SaveTest")]
        public ActionResult Test(TestingFile _test)
        {
            if (ModelState.IsValid)
            {
                return Json("Data Insert");
            }
            return View("TestIndex");

        }
        [HttpGet]
        [Route("EditMasterData/{Id}")]

        public ActionResult EditMasterData(int Id)
        {
            EditViewModel _EditViewModel = new EditViewModel();
            var _Data = _ObjRepo.GetMasterById(Id);
            if (_Data.Count > 0)
            {
                var _CountryData = _ObjRepo.GetCountry();
                var _stateData = _ObjRepo.GetStateById(_Data[0].StateId);
                var _CityData = _ObjRepo.GetCityById(_Data[0].CityId);
                //Binding Master Data
                _EditViewModel._ListMasterTable = _Data;
                //Binding Country Data         
                _EditViewModel._EditCountryData = _CountryData;
                //Binding State Data         
                _EditViewModel._EditStateData = _stateData;
                //Binding City Data         
                _EditViewModel._EditCityData = _CityData;

                return View(_EditViewModel);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }


        public  ActionResult UpdatedMaster(EditViewModel _mastyer)
        {
            if (ModelState.IsValid)
            {
                MasterTable _objmaster = new MasterTable();
                _objmaster.ContryId = Convert.ToInt16(Request.Form["_MasterTable.ContryId"]);
                _objmaster.StateId = Convert.ToInt16(Request.Form["_MasterTable.StateId"]);
                _objmaster.CityId = Convert.ToInt16(Request.Form["_MasterTable.CityId"]);
                _objmaster.Master_Email = (Request.Form["_MasterTable.Master_Email"]);
                _objmaster.Master_Name = Convert.ToString(Request.Form["_MasterTable.Master_Name"]);
            }


            return RedirectToAction("EditMasterDatadetails/"+2);
        }

        public ActionResult EditMasterDatadetails(int Id)
            {
            EditViewModel _EditViewModel = new EditViewModel();
            var _Data = _ObjRepo.GetMasterById(Id);
            if (_Data.Count > 0)
            {
                //foreach(var xx in _Data)
                //{
                //    MasterTable _obj = new MasterTable();
                //    _obj.Id = xx.Id;
                //    _EditViewModel._ListMasterTable.Add(_obj);
                //}
                var _CountryData = _ObjRepo.GetCountry();
                var _stateData = _ObjRepo.GetStateNameById(_Data[0].StateId);
                var _CityData = _ObjRepo.GetCity_Name_ById(_Data[0].CityId);
                //Binding Master Data
                _EditViewModel._ListMasterTable = _Data;
                //Binding Country Data         
                _EditViewModel._EditCountryData = _CountryData;
                //Binding State Data         
                _EditViewModel._EditStateData = _stateData;
                //Binding City Data         
                _EditViewModel._EditCityData = _CityData;

                return PartialView("EditMasterDatadetails", _EditViewModel);

            }
            else
            {
                return View("Index");

            }
        }
    }
}