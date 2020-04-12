using System.ComponentModel.DataAnnotations;

namespace GiaiNganAPI.Entities.System
{
    public class MasUserModel : BasicModel 
    {
        [Required]
        public int COMPANY_ID { get; set; }
        [Required]
        public int USER_ID { get; set; }
        [Required]
        [StringLength(50)]
        public string USER_NM { get; set; }
        public byte[] PASSWORD { get; set; }
        public string PASSWORD_SALT { get; set; }

        public string NEW_PASSWORD { get; set; }

        [StringLength(100)]
        public string FULL_NAME { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string EMAIL { get; set; }
        [StringLength(100)]
        public string USER_MAIN_SCR { get; set; }
        [StringLength(20)]
        public string USER_LANGUAGE { get; set; }
        [StringLength(50)]
        public string AVATAR { get; set; }

        public int ORG_ID { get; set; }
        [StringLength(12)]
        public string POSITION_GEN_CD { get; set; }
        [Required]
        public bool SUPER_YN { get; set; }
        [Required]
        public bool TEMP_PASS_CHANGE_YN { get; set; }
    }

    public class MasUserChangePassModel
    {
        public string PASSWORD { get; set; }
        public string NEW_PASSWORD { get; set; }
    }
}
