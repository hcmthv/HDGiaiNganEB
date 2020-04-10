using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;

using GiaiNganAPI.DAL.Core;
using GiaiNganAPI.Entities.System;
using Dapper;
using System.Data;

namespace GiaiNganAPI.DAL.Dapper
{
    public class MasUserManager : dapperDAL
    {
        public static MasUserManager Instance { get; } = new MasUserManager();

        public bool CheckUserName(string pUsername)
        {
            try
            {
                var l_sql = "select * from  vw_getUsers where user_nm = @p_username";
                //MasUserModel lMasUser = new MasUserModel();
                using (var conn = openConnection())
                {
                    string username = pUsername;
                    conn.QueryFirst<MasUserModel>(l_sql, new { p_username = username });
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ChangePassWord(string pUserName, string pPassword)
        {
            try
            {
                var l_sql = "select * from vw_getuserdetails where password =  dbo.HmacSha256(CONCAT(@p_password,password_salt)) and user_nm = @p_usernm";
                //MasUserModel lMasUser = new MasUserModel();
                using (var conn = openConnection())
                {
                    string password = pPassword;
                    conn.QueryFirst<MasUserModel>(l_sql, new { p_password = password, p_usernm = pUserName });
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CheckPassword(string pPassword)
        {
            try
            {
                var l_sql = "select * from vw_getuserdetails where password =  dbo.HmacSha256(CONCAT(@p_password,password_salt))";
                //MasUserModel lMasUser = new MasUserModel();
                using (var conn = openConnection())
                {
                    string password = pPassword;
                    conn.QueryFirst<MasUserModel>(l_sql, new { p_password = password });
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<MasUserRequestModel> CheckLogin(LoginModel pUser)
        {
            List<MasUserRequestModel> lUser = new List<MasUserRequestModel>();
            try
            {
                var lSql = "select * from vw_getuserdetails where user_nm = @p_username and password = dbo.HmacSha256(CONCAT(@p_password,password_salt))";
                using (var conn = openConnection())
                {
                    string username = pUser.Username;
                    string password = pUser.Password;
                    lUser = conn.Query<MasUserRequestModel>(lSql, new { p_username = username, p_password = password }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lUser;
        }

        public int ProcessSql(string status = null, MasUserModel pMasUser = null)
        {
            int iResult = -1;
            var conn = openConnection();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("p_status", status);
                if (pMasUser != null)
                {
                    param.Add("P_COMPANY_ID", pMasUser.COMPANY_ID);
                    //param.Add("P_USER_CD", pMasUser.USER_CD);
                    param.Add("P_USER_ID", pMasUser.USER_ID);
                    param.Add("P_USER_NM", pMasUser.USER_NM);
                    //param.Add("P_FULLNAME", pMasUser.FULL_NAME);
                    param.Add("P_PASSWORD", pMasUser.PASSWORD);
                    // param.Add("P_PASSWORD_SALT", pMasUser.PASSWORD_SALT);
                    param.Add("P_FULL_NAME", pMasUser.FULL_NAME);
                    param.Add("P_EMAIL", pMasUser.EMAIL); // CHANGED USER_EMAIL TO EMAIL
                    param.Add("P_USER_MAIN_SCR", pMasUser.USER_MAIN_SCR);
                    param.Add("P_USER_LANGUAGE", pMasUser.USER_LANGUAGE); // CHANGED FROM PROFILE_IMAGE

                    param.Add("P_AVATAR", pMasUser.AVATAR); // CHANGED FROM PROFILE_IMAGE
                    param.Add("P_ORG_ID", pMasUser.ORG_ID);
                    param.Add("P_POSITION_GEN_CD", pMasUser.POSITION_GEN_CD);


                    param.Add("P_SUPER_YN", pMasUser.SUPER_YN);
                    param.Add("P_TEMP_PASS_CHANGE_YN", pMasUser.TEMP_PASS_CHANGE_YN);


                    //param.Add("P_SETTING_YMD", pMasUser.SETTING_YMD);
                    //param.Add("P_USE_SYS", pMasUser.USE_SYS);

                    param.Add("P_USE_YN", pMasUser.USE_YN);
                    param.Add("P_REMARK", pMasUser.REMARK);

                    if (pMasUser.CREATED_TIME == DateTime.MinValue || pMasUser.CHANGED_TIME == DateTime.MinValue)
                    {
                        pMasUser.CREATED_TIME = DateTime.Now;
                        pMasUser.CHANGED_TIME = DateTime.Now;
                    }

                    param.Add("P_CREATOR", pMasUser.CREATOR);
                    param.Add("P_CREATED_TIME", pMasUser.CREATED_TIME);

                    param.Add("P_CHANGER", pMasUser.CHANGER);
                    param.Add("P_CHANGED_TIME", pMasUser.CHANGED_TIME);

                    /*param.Add("P_BIZ_UNIT_UID", pMasUser.BIZ_UNIT_UID);
					param.Add("P_BIZPLACE_CD", pMasUser.BIZPLACE_CD);
					param.Add("P_HR_CD", pMasUser.HR_CD);*/

                    param.Add("P_DEL_YN", pMasUser.DEL_YN);

                }

                param.Add("@p_outValue", dbType: DbType.Int64, direction: ParameterDirection.Output);

                conn.Open();
                iResult = conn.Execute("sp_zm_mas_user", param, null, null, commandType: CommandType.StoredProcedure);

                if (status == "INSERT")
                {
                    Int64 outValue = param.Get<Int64>("@p_outValue");
                }

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return iResult;
        }

        public List<MasUserModel> GetMasUsers(int? l_CompanyId = null)
        {
            List<MasUserModel> lUserList = new List<MasUserModel>();
            try
            {
                var lSql = "select * from vw_getusers where company_id like (case when isnull(@p_CompanyId,'') = '' then '%' else @p_CompanyId end) ";

                using (var conn = openConnection())
                {
                    lUserList = conn.Query<MasUserModel>(lSql, new { p_CompanyId = l_CompanyId }).ToList();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return lUserList;
        }

        public List<MasUserModel> GetMasUserDetails(int? id = null)
        {
            List<MasUserModel> lUserList = new List<MasUserModel>();
            try
            {
                var lSql = "select * from vw_getusers where user_cd = @p_usercd";

                using (var conn = openConnection())
                {
                    lUserList = conn.Query<MasUserModel>(lSql, new { p_usercd = id }).ToList();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return lUserList;
        }

        public List<MasUserModel> GetMasUserList(MasUserRequestModel pMasUser = null)
        {
            List<MasUserModel> lUserList = new List<MasUserModel>();
            try
            {
                if (pMasUser == null) pMasUser = new MasUserRequestModel();
                var l_sql = "select * from vw_getusers " +
                    "  where user_cd like ( case when @p_user_cd = 0 then '%' else @p_user_cd end )  and " +
                    "  user_nm like( case when coalesce(@p_user_nm, '') = '' or  @p_user_nm = '' then '%' else  concat(@p_user_nm, '%') end) ";

                using (var conn = openConnection())
                {
                    lUserList = conn.Query<MasUserModel>(l_sql, new { p_user_cd = pMasUser.USER_ID, p_user_nm = pMasUser.USER_NM }).ToList();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return lUserList;
        }
    }
}
