using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_DLL.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using MVC_DLL.AES256Encryption;
using System.Data.Entity;

namespace MVC_DLL.BusinessLogis
{
    public class Repo : IRepo
    {
        #region Cascading Dropdown   
        /// <summary>
        /// Getting Country List
        /// </summary>
        /// <returns></returns>
          //  SqlConnectionImplemntation _dbConnectors = new SqlConnectionImplemntation();
        public List<Country> GetCountry()
        {
            dbConnector _dbConnectors = new dbConnector();
            using (SqlConnection Conn = _dbConnectors.GetConnection) {
                Conn.Open();
                try
                {
                    List<Country> _listCustomer = new List<Country>();
                    if (Conn.State != ConnectionState.Open)
                        Conn.Open();
                    SqlCommand objCommand = new SqlCommand("Usp_GetCountryList", Conn);
                    objCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader _Reader = objCommand.ExecuteReader();
                    while (_Reader.Read())
                    {
                        Country objCust = new Country();
                        objCust.Cnt_Id = Convert.ToInt32(_Reader["Cnt_Id"]);
                        objCust.Cnt_Name = Convert.ToString(_Reader["Cnt_Name"]);
                        _listCustomer.Add(objCust);
                    }
                    return _listCustomer;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    if (Conn != null)
                    {
                        if (Conn.State == ConnectionState.Open)
                        {
                            Conn.Close();
                            //Conn.Dispose();
                        }
                    }
                }
            }
        }
        public List<City> GetCityById(int StateId)
        {
            dbConnector _dbConnectors = new dbConnector();
            SqlConnection conn = _dbConnectors.GetConnection;
            conn.Open();
            try
            {
                List<City> _citys = new List<City>();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                SqlCommand _command = new SqlCommand("Usp_GetCityList", conn);
                _command.CommandType = CommandType.StoredProcedure;
                _command.Parameters.AddWithValue("@State_Id", StateId);
                SqlDataReader _Reader = _command.ExecuteReader();
                while (_Reader.Read())
                {
                    City _ObjCity = new City();
                    _ObjCity.City_Id = Convert.ToInt32(_Reader["City_Id"]);
                    _ObjCity.City_Name = Convert.ToString(_Reader["City_Name"]);
                    _ObjCity.City_Sts_Id = Convert.ToInt32(_Reader["City_Sts_Id"]);
                    _citys.Add(_ObjCity);

                }
                return _citys;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }

        }

        public List<State> GetStateById(int cntId)
        {
            dbConnector _dbConnectors = new dbConnector();
            SqlConnection con = _dbConnectors.GetConnection;
            con.Open();
            try
            {
                List<State> _ListStates = new List<State>();
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand _command = new SqlCommand("Usp_GetStateList", con);
                _command.CommandType = CommandType.StoredProcedure;
                _command.Parameters.AddWithValue("@Cnt_Id", cntId);
                SqlDataReader _Reader = _command.ExecuteReader();
                while (_Reader.Read())
                {
                    State _states = new State();
                    _states.Sts_Id = Convert.ToInt32(_Reader["Sts_Id"]);
                    _states.Sts_Name = Convert.ToString(_Reader["Sts_Name"]);
                    _states.Sts_Cnt_Id = Convert.ToInt32(_Reader["Sts_Cnt_Id"]);
                    _ListStates.Add(_states);
                }
                return _ListStates;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            throw new NotImplementedException();
        }


        public List<State> GetStateNameById(int cntId)
        {
            dbConnector _dbConnectors = new dbConnector();
            SqlConnection con = _dbConnectors.GetConnection;
            con.Open();
            try
            {
                List<State> _ListStates = new List<State>();
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand _command = new SqlCommand("USP_Get_stateName_By_ID", con);
                _command.CommandType = CommandType.StoredProcedure;
                _command.Parameters.AddWithValue("@CntId", cntId);
                SqlDataReader _Reader = _command.ExecuteReader();
                while (_Reader.Read())
                {
                    State _states = new State();
                    _states.Sts_Id = Convert.ToInt32(_Reader["Sts_Id"]);
                    _states.Sts_Name = Convert.ToString(_Reader["Sts_Name"]);
                    _states.Sts_Cnt_Id = Convert.ToInt32(_Reader["Sts_Cnt_Id"]);
                    _ListStates.Add(_states);
                }
                return _ListStates;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            throw new NotImplementedException();
        }

        public List<City> GetCity_Name_ById(int StateId)
        {
            dbConnector _dbConnectors = new dbConnector();
            SqlConnection conn = _dbConnectors.GetConnection;
            conn.Open();
            try
            {
                List<City> _citys = new List<City>();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                SqlCommand _command = new SqlCommand("USP_Get_CityName_By_ID", conn);
                _command.CommandType = CommandType.StoredProcedure;
                _command.Parameters.AddWithValue("@State", StateId);
                SqlDataReader _Reader = _command.ExecuteReader();
                while (_Reader.Read())
                {
                    City _ObjCity = new City();
                    _ObjCity.City_Id = Convert.ToInt32(_Reader["City_Id"]);
                    _ObjCity.City_Name = Convert.ToString(_Reader["City_Name"]);
                    _ObjCity.City_Sts_Id = Convert.ToInt32(_Reader["City_Sts_Id"]);
                    _citys.Add(_ObjCity);

                }
                return _citys;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
            }

        }

        #endregion
        #region Inserting Master Data  
        public List<MasterTable> GetMasterTableData()
        {
            dbConnector _dbconnection = new dbConnector();
            SqlConnection con = _dbconnection.GetConnection;
            con.Open();
            try
            {
                List<MasterTable> _mat = new List<MasterTable>();
                if (con.State != ConnectionState.Open)
                    con.Open();
                SqlCommand _cmd = new SqlCommand("select * from Usp_GetMasterData", con);
                _cmd.CommandType = CommandType.Text;
                SqlDataReader READER = _cmd.ExecuteReader();
                while (READER.Read())
                {
                    MasterTable _mastertab = new MasterTable();
                    _mastertab.Master_Email = Convert.ToString(READER["Master_Email"]);
                    _mastertab.PassWord = Convert.ToString(READER["PassWord"]);
                    _mastertab.Master_Token = Convert.ToString(READER["Master_Token"]);
                    _mastertab.Master_Name = Convert.ToString(READER["Master_Name"]);
                    _mastertab.Id = Convert.ToInt32(READER["Id"]);

                    _mat.Add(_mastertab);
                }
                return _mat;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }

        public int InsertData(MasterTable _master)
        {
            dbConnector _dbconnector = new dbConnector();
            SqlConnection con = _dbconnector.GetConnection;
            con.Open();      
             try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                var _key = EncryptionLibrary.EncryptText(_master.PassWord);
                SqlCommand _commd = new SqlCommand("Usp_InsertMaster", con);
                _commd.CommandType = CommandType.StoredProcedure;
                _commd.Parameters.AddWithValue("@UserID", 1);
                _commd.Parameters.AddWithValue("@Master_Name", _master.Master_Name);
                _commd.Parameters.AddWithValue("@Master_Email", _master.Master_Email);
                _commd.Parameters.AddWithValue("@PassWord", _key);
                _commd.Parameters.AddWithValue("@ImageId", _master.ImageId);
                _commd.Parameters.AddWithValue("@ContryId", _master.ContryId);
                _commd.Parameters.AddWithValue("@StateId", _master.StateId);
                _commd.Parameters.AddWithValue("@CityId", _master.CityId);
                int _finalresult = _commd.ExecuteNonQuery();
              //  int _finalresult =Convert.ToInt32( _commd.ExecuteScalar());
                return _finalresult;
            }                     
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }
        #endregion

        public List<MasterTable> GetMasterById(int Id)
        {
            dbConnector _dbconnector = new dbConnector();
            SqlConnection con = _dbconnector.GetConnection;
            con.Open();
            MasterTable _master = new MasterTable();
            try
            {
                if (con.State != ConnectionState.Open)
                    con.Open();
                List<MasterTable> _ListStates = new List<MasterTable>();
                SqlCommand _commd = new SqlCommand("Usp_GetMasterDataBy_Id", con);
                _commd.CommandType = CommandType.StoredProcedure;
                _commd.Parameters.AddWithValue("@Id", Id);
                SqlDataReader _Reader = _commd.ExecuteReader();
                while (_Reader.Read())
                {
                    _master.Id = Convert.ToInt32(_Reader["Id"]);
                    _master.Master_Name = Convert.ToString(_Reader["Master_Name"]);
                    _master.Master_Token = Convert.ToString(_Reader["Master_Token"]);
                    _master.Master_Email = Convert.ToString(_Reader["Master_Email"]);
                    _master.ContryId = Convert.ToInt32(_Reader["ContryId"]);
                    _master.StateId = Convert.ToInt32(_Reader["StateId"]);
                    _master.CityId = Convert.ToInt32(_Reader["CityId"]);

                    _ListStates.Add(_master);
                }
                return _ListStates;
               // return _master;



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

  
}

