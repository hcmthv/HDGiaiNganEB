using System;
using System.Collections.Generic;
using System.Text;

namespace GiaiNganAPI.DAL.EF
{
    public partial class HDMasUser
    {
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public string UserNm { get; set; }
        public string Password { get; set; }
        public string PassswordSalt { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserMainScr { get; set; }
        public string UserLanguage { get; set; }
        public string Avatar { get; set; }
        public int? OrgId { get; set; }
        public string OrgGenCd { get; set; }
        public string PositionGenCd { get; set; }
        public bool SuperYn { get; set; }
        public bool TempPassChangeYn { get; set; }
        public bool? UseYn { get; set; }
        public string Remark { get; set; }
        public string Creator { get; set; }
        public DateTime CreatedTime { get; set; }
        public string Changer { get; set; }
        public DateTime ChangedTime { get; set; }
        public bool? DelYn { get; set; }
    }
}
