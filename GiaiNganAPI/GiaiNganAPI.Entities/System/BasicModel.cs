using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace GiaiNganAPI.Entities.System
{
    public class BasicModel
    {
        [Required]
        public bool USE_YN { get; set; }
        [StringLength(400)]
        public string REMARK { get; set; }
        //[Required]
        [StringLength(50)]
        public string CREATOR { get; set; }
        [Required]
        [JsonIgnore]
        public DateTime CREATED_TIME { get; set; }
        //[Required]
        [StringLength(50)]
        public string CHANGER { get; set; }
        [Required]
        [JsonIgnore]
        public DateTime CHANGED_TIME { get; set; }
        [Required]
        [JsonIgnore]
        public bool DEL_YN { get; set; }

        [JsonProperty("CREATED_TIME")]
        public string CREATED_TIME_STR
        {
            get
            {
                return CREATED_TIME.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        [JsonProperty("CHANGED_TIME")]
        public string CHANGED_TIME_STR
        {
            get
            {
                return CHANGED_TIME.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
    }
}
