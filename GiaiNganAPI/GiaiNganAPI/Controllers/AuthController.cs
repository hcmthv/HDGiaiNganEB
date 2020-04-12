using GiaiNganAPI.Services.System;
using GiaiNganAPI.Interfaces.System;
using GiaiNganAPI.Entities.System;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GiaiNganAPI
{
    [Authorize]
    [Produces("application/json")]
    [Route("[Controller]/[Action]")]
    public class AuthController : Controller
    {
        private readonly IMasUserService _masUserService;
        private readonly IConfiguration _config;
        public AuthController(IConfiguration config, IMasUserService masUserService)
        {
            _config = config;
            _masUserService = masUserService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel login)
        {
            return CreateToken(login);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            //var tokenSource = new CancellationTokenSource();
            //var token = tokenSource.Token;

            //tokenSource.Cancel();
            //// await HttpContext.SignOutAsync();

            return  await Task.Run(() => Json( new { status = "fail", data = "" } ));          
        }

        [HttpGet]
        [Authorize("Bearer")]
        public string GetUserInfo()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;

            return JsonConvert.SerializeObject(new
            {
                UserName = claimsIdentity.Name
            });
        }

        public IActionResult CreateToken(LoginModel login)
        {
            IActionResult response = Unauthorized();            
            
            var user = Authenticate(login);
            if (user != null)
            {              

                var tokenString = BuildToken(user);
                // response = Ok(new { token = tokenString });                
                return Json(new { success = true, data = new { token = tokenString,
                    company_id = user.COMPANY_ID,
                    company_nm = user.company_nm,
                    user_cd = user.USER_ID, user_name = user.USER_NM, full_name = user.FULL_NAME,
                    org_id = user.ORG_ID,
                    org_nm = user.org_nm,
                    position_gen_cd = user.POSITION_GEN_CD,
                    position_nm = user.position_nm,
                    user_language = user.USER_LANGUAGE,
                    //biz_unit_uid = user.BIZ_UNIT_UID,
                    biz_unit_nm = user.biz_unit_nm,
                    //bizplace_cd = user.BIZPLACE_CD,
                    //hr_cd = user.HR_CD,
                    //hr_nm = user.hr_nm,
                    avatar = user.AVATAR ?? "/assets/img/avatars/default.png" } });
            }
            else {
                //Task<bool> l_username = Users.Instance.CheckUserName(login.Username);
                //Task<bool> l_password = Users.Instance.CheckPassword(login.Password);
                //ErrorModel error = null;
                //if ((bool)l_username.Result == false && (bool)l_password.Result == true)
                //{
                //    error = new ErrorModel() { code = 2000, message = "Username is incorrect" };
                //}

                //if ((bool)l_username.Result == true && (bool)l_password.Result == false)
                //{
                //    error = new ErrorModel() { code = 2000, message = "Password is incorrect" };
                //}

                //if ((bool)l_username.Result == false && (bool)l_password.Result == false)
                //{
                //    error = new ErrorModel() { code = 2000, message =  "Username and Password are incorrect" };
                //}

                return Json(new { error = new { code = 2000, message = "Username or password is incorrect" } });
            }
                
        }

        private string BuildToken(MasUserModel masUser)
        {                      
            List<Claim> claims = new List<Claim>
            {
                new Claim("name", masUser.USER_NM),
                new Claim("nameidentifier", masUser.USER_ID.ToString()),
                new Claim("identityprovider", "AtmanEuler"),
                new Claim("fullname", masUser.USER_NM),
                new Claim("companyid", masUser.COMPANY_ID.ToString()),
            };
               
            var extra = new ClaimsIdentity();
            extra.AddClaim(new Claim(ClaimTypes.Name, masUser.USER_NM));
            extra.AddClaims(claims);

            //var claims = new[] { new Claim(ClaimTypes.Name, masUser.USER_NM) }            

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              _config["Jwt:Issuer"],
               _config["Jwt:Issuer"],
              extra.Claims,
              expires: DateTime.Now.AddHours(10),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private MasUserRequestModel Authenticate(LoginModel login)
        {            
            try
            {
                MasUserRequestModel lMasUser = null;
                var o = _masUserService.CheckLogin(login);
                if (o.Result.Count > 0)
                {
                    lMasUser = o.Result[0];
                }

                return lMasUser;
            }
            catch
            {
                return new MasUserRequestModel();
            }
        }


        //public IActionResult Login()
        //{
        //    return View();
        //}

        //private IActionResult GoToReturnUrl(string returnUrl)
        //{
        //    if (Url.IsLocalUrl(returnUrl))
        //    {
        //        return Redirect(returnUrl);
        //    }
        //    return RedirectToAction("Index", "Home");
        //}

        //public IActionResult Denied()
        //{
        //    return View();
        //}

        //public async Task<IActionResult> Logout()
        //{
        //    await HttpContext.SignOutAsync();
        //    return RedirectToAction(nameof(Login));
        //}
    }
}