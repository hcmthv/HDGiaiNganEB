using System;
using System.Collections.Generic;

using GiaiNganAPI.Interfaces.System;
using GiaiNganAPI.Entities.System;
using GiaiNganAPI.DAL.Dapper;
using System.Threading.Tasks;

namespace GiaiNganAPI.Services.System
{
    public class MasUserService : IMasUserService
    {
        public async Task<bool> CheckUserName(string pUsername)
        {
            return await Task.Run(() => MasUserManager.Instance.CheckUserName(pUsername));
        }

        public async Task<bool> CheckPassword(string pPassword)
        {
            return await Task.Run(() => MasUserManager.Instance.CheckPassword(pPassword));
        }

        public async Task<bool> ChangePassWord(string pUserNM, string pPassword)
        {
            return await Task.Run(() => MasUserManager.Instance.ChangePassWord(pUserNM, pPassword));
        }

        public async Task<List<MasUserRequestModel>> CheckLogin(LoginModel pUser)
        {
            return await Task.Run(() => MasUserManager.Instance.CheckLogin(pUser));
        }

        public async Task<List<MasUserModel>> GetMasUserList(MasUserRequestModel pMasUser)
        {
            return await Task.Run(() => MasUserManager.Instance.GetMasUserList(pMasUser));
        }

        public async Task<List<MasUserModel>> GetMasUsers(int? l_CompanyId = null)
        {
            return await Task.Run(() => MasUserManager.Instance.GetMasUsers(l_CompanyId));
        }

        public async Task<List<MasUserModel>> GetMasUserDetails(int? userId = null)
        {
            return await Task.Run(() => MasUserManager.Instance.GetMasUserDetails(userId));
        }

        public async Task<int> ProcessSql(string status = null, MasUserModel pMasUser = null)
        {
            return await Task.Run(() => MasUserManager.Instance.ProcessSql(status, pMasUser));
        }

        public async Task<int> InsertMasUser(MasUserModel pMasUser = null)
        {
            int iResult = -1;
            try
            {
                iResult = await ProcessSql("INSERT", pMasUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return iResult;
        }

        public async Task<int> UpdateMasUser(MasUserModel pMasUser = null)
        {
            return await ProcessSql("UPDATE", pMasUser);
        }

        public async Task<int> DeleteMasUser(MasUserModel pMasUser = null)
        {
            return await ProcessSql("DELETE", pMasUser);
        }

        public async Task<int> ResetMasUser(MasUserModel pMasUser = null)
        {
            return await ProcessSql("RESET", pMasUser);
        }
    }
}
