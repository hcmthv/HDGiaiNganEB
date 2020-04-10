using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GiaiNganAPI.Entities.System;

namespace GiaiNganAPI.Interfaces.System
{
    public interface IMasUserService
    {
        Task<bool> CheckUserName(string pUsername);
        Task<bool> CheckPassword(string pPassword);
        Task<bool> ChangePassWord(string pUserNM, string pPassword);

        Task<List<MasUserRequestModel>> CheckLogin(LoginModel pUser);
        Task<List<MasUserModel>> GetMasUserList(MasUserRequestModel pMasUser = null);

        Task<List<MasUserModel>> GetMasUsers(int? l_CompanyId = null);
        Task<List<MasUserModel>> GetMasUserDetails(int? userId = null);
        Task<int> ProcessSql(string status = null, MasUserModel pMasUser = null);

        Task<int> InsertMasUser(MasUserModel pMasUser = null);
        Task<int> UpdateMasUser(MasUserModel pMasUser = null);
        Task<int> DeleteMasUser(MasUserModel pMasUser = null);
        Task<int> ResetMasUser(MasUserModel pMasUser = null);
    }   
}
