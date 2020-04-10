using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiaiNganAPI.Attribute
{
    public class Authenticate 
    {
        public static Authenticate Instance { get; } = new Authenticate();

        public string GetValueObject(string key, System.Security.Claims.ClaimsPrincipal User)
        {
            string value = string.Empty;
            foreach (var identity in User.Identities)
            {
                foreach (var claim in identity.Claims)
                {
                    if (claim.Type == key)
                    {
                        return claim.Value;
                    }
                }
            }
            return "";
        }
    }
}
