using System;
using System.Collections.Generic;
using System.Text;

namespace GiaiNganAPI.Entities.System
{
    public class MasUserRequestModel : MasUserModel
    {
        public string company_nm { get; set; }
        public string org_nm { get; set; }
        public string position_nm { get; set; }
        public string biz_unit_nm { get; set; }
        public string hr_nm { get; set; }
    }    
}
