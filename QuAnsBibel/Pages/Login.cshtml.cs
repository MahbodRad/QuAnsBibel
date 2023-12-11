using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.IO;
using QuAnsBibel.Services;
using QuAnsBibel.Models;

namespace QuAnsBibel.Pages
{
    public class LoginModel : PageModel
    {
         
        private readonly string DbConect = Center.DbConect();
        string ComText = "";
        [BindProperty(Name = "_Page", SupportsGet = true)]
        public string _Page { get; set; }


//        public LoginInfo _LoginInfo = new LoginInfo();
//        public FormSetup _FormSetup;
        public IdValuTp _IdValuTp;

        [BindProperty]
        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        [Required(ErrorMessage = "لطفا {0} را بنویسید")]
        [Display(Name = "نام کاربری")]
        [BindProperty] 
        public string LoginName { get; set; }
            
        [Required(ErrorMessage = "لطفا {0} را بنویسید")]
        [Display(Name = "رمز ورود به سامانه")]
        [DataType(DataType.Password)]
        [BindProperty]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        [BindProperty]
        public string ResTp { get; set; }

        private Microsoft.AspNetCore.Hosting.IWebHostEnvironment _hostingEnvironment;
        public LoginModel(Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostingEnvironment)
        {// مسیر روت برنامه
            _hostingEnvironment = hostingEnvironment;
        }
        public void OnGet(string returnUrl = null)
        {
           
            if (returnUrl == null)
            returnUrl = "/MNG/Home";

            if (Request.Cookies["Login.QuAnsBibel.ir"] != null)
            {
                var legacyCookie = Request.Cookies["Login.QuAnsBibel.ir"].ToString();//  FromLegacyCookieString();
               // var username = legacyCookie["U"];

               // LoginName = username;
            }
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }
            // _FormSetup = new FormSetup();
            // HeaderFooter();

            _Page = returnUrl;
        }

        string _LoginName;
        string _Password;
        bool _Remember;
        public IActionResult OnPostLogin(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            Response.Cookies.Delete("QuAnsBibel.ir");

            _LoginName = LoginName;
            _Password = Password;
            _Remember = RememberMe;

            if (ModelState.IsValid)
            {

                string key2 = "ziKm87NIqRetFkL41975upvwF^*()e54fGnOgHhjAaBrSsoPzpQCcbx*!632yDdElMO910JKAGHIPQfg#$67";
                var r2 = new Random();
                StringBuilder token = new StringBuilder();
                int idx2 = 0;
                for (int i = 0; i < 75; i++)
                {
                    idx2 = r2.Next(0, 79);
                    token.Append(key2.Substring(idx2, 1));
                }
                string IIP = HttpContext.Connection.RemoteIpAddress.ToString();
                ComText = "Exec [dbo].[Users_Login] '";
                ComText += _LoginName;
                ComText += "', '" + _Password.Trim();
                ComText += "', '" + IIP;
                ComText += "', '" + token.ToString();
                ComText += "'";

                string Res = "";
                //   string MSG = "";
                using (SqlConnection Con = new SqlConnection(DbConect))
                {
                    Con.Open();
                    using (SqlCommand Com = new SqlCommand(ComText, Con))
                    {
                        using (SqlDataReader RDR = Com.ExecuteReader())
                        {
                            RDR.Read();
                            Res = RDR["Res"].ToString();

                            if (Res == "OK")
                            {
                             //   _LoginInfo.Si = RDR["Si"].ToString();
                             //   _LoginInfo.Name = RDR["UsrName"].ToString();
                             //   _LoginInfo.Knd = RDR["Knd"].ToString();
                             //   _LoginInfo.Token = token.ToString();
                                Response.Cookies.Delete("Login.QuAnsBibel.ir");
                                CookieOptions option = new CookieOptions()
                                {
                                    Path = "/",
                                    HttpOnly = false,
                                    IsEssential = true,
                                    Expires = DateTime.Now.AddDays(365),
                                };
                                Response.Cookies.Append("QuAnsBibel.ir", token.ToString(), option);

                                return RedirectToPage(_Page);

                            }
                            else
                            {
                                ViewData["Restp"] = Res;// "خطا در ورود اطلاعات پسورد و نام کاربری";
                                return Page();
                            }
                        }
                    }
                }
            }
            else
            {
                return Page();
            }
        }
        private void HeaderFooter()
        {
            ComText = "EXEC [dbo].[Help_HFShow] '0'";
            using (var DS = Center.RunReport(DbConect, ComText))
            {
                DataRow DRow = DS.Tables["RES"].Rows[0];
             //   _FormSetup.Header = DRow["Header"].ToString();
             //   _FormSetup.Footer = DRow["Footer"].ToString();
            }
        }

        public IActionResult OnPostHelpShow()
        {
            ComText = "EXEC [dbo].[Help_Show] '0'";
            using (var DS = Center.RunReport(DbConect, ComText))
            {
                DataRow DRow = DS.Tables["RES"].Rows[0];

                _IdValuTp = new IdValuTp
                {
                    Id = DRow["Si"].ToString(),
                    Value = "راهنمای " + DRow["Form"].ToString(),
                    Tp = DRow["Tp"].ToString(),
                };
            }
            string folderName = @"Upload\Help\";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string PicPath = Path.Combine(webRootPath, folderName);
            string fullPath = "";
            fullPath = Path.Combine(PicPath, "H_" + _IdValuTp.Id + ".jpg");
            if (System.IO.File.Exists(fullPath))
            {
                _IdValuTp.Reg = "/Upload/Help/H_" + _IdValuTp.Id + ".jpg";
            }
            else { _IdValuTp.Reg = ""; }

            ViewData["Switch"] = "Help";
            return new PartialViewResult
            {
                ViewName = "Login_View",
                ViewData = this.ViewData
            };
        }

    }
}
