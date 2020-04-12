using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace GiaiNganAPI.Models
{
    public class SharingGroupUserAddUpdateModel
    {
        [Required]
        [JsonProperty("company_id")]
        public int CompanyId { get; set; }
        [Required]
        [JsonProperty("sharing_group_id")]
        public int SharingGroupId { get; set; }
        [Required]
        [Range(1, 10000000)]
        [JsonProperty("menu_id")]
        public int MenuId { get; set; }

        [Required]
        [JsonProperty("user_id")]
        public int[] UserId { get; set; }

        public string Remark { get; set; }

        [JsonProperty("use_yn")]
        public bool UseYn { get; set; } = true;
    }

    public class SharingGroupUserDeleteModel
    {
        [Required]
        [JsonProperty("company_id")]
        public int CompanyId { get; set; }
        [Required]
        [JsonProperty("sharing_group_id")]
        public int SharingGroupId { get; set; }
        [Required]
        [Range(1, 10000000)]
        [JsonProperty("menu_id")]
        public int MenuId { get; set; }

        [Required]
        [JsonProperty("user_id")]
        public int UserId { get; set; }

    }
}