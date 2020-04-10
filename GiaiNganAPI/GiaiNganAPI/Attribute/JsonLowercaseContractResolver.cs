using Newtonsoft.Json.Serialization;

namespace GiaiNganAPI
{
    public class JsonLowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}