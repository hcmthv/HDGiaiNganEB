using GiaiNganAPI.Config;
using GiaiNganAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace erpsolution.api.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        /// <summary>
        /// Username that authorized
        /// </summary>
        public string UserCreator => HttpContext.User.Identity.Name;

        public ErrorResponseModel Error(ErrorCode code, string message = null)
        {
            if (string.IsNullOrEmpty(message))
            {
                switch (code)
                {
                    case ErrorCode.DATA_INVALID:
                        message = "Data invalid";
                        break;
                    default:
                        message = "System error!";
                        break;
                }
            }
            return new ErrorResponseModel
            {
                Error = new ErrorModel() { ErrorCode = code.GetHashCode(), ErrorMessage = message }
            };
        }

        public string ClientIp => Request.HttpContext.Connection.RemoteIpAddress.ToString();
        public string ClientInfo => Request.Headers["User-Agent"];
    }
}