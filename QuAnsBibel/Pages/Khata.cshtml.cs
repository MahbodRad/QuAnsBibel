using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuAnsBibel.Models;
using QuAnsBibel.Services;

namespace QuAnsBibel.Pages
{
    public class KhataModel : PageModel
    {
        private readonly string DbConect = Center.DbConect();
        string ComText = "";

        public LoginInfo _LoginInfo = new LoginInfo();
        public FormSetup _FormSetup;
        public IdValuTp _IdValuTp;

        private Microsoft.AspNetCore.Hosting.IWebHostEnvironment _hostingEnvironment;
        public KhataModel(Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostingEnvironment)
        {// مسیر روت برنامه
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult OnGet(string returnUrl = "HOME")
        {
            try
            {
                ViewData["_Page"]  = returnUrl;

                //           Center.ListForms(DbConect, Request.Cookies["QuAnsBibel.OfficeWeb.ir"].ToString(), _FormSetup, Form_List, _LoginInfo, "29");

                return Page();
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Login", new { returnUrl = "/Home" });
            }
        }


        public IActionResult OnGetHelpShow()
        {
            try
            {
                ComText = "EXEC [dbo].[Forms_Help] '29'";
                using (var DS = Center.RunReport(DbConect, ComText))
                {
                    DataRow DRow = DS.Tables["RES"].Rows[0];

                    _IdValuTp = new IdValuTp
                    {
                        Id = DRow["Si"].ToString(),
                        Value = "راهنمای " + DRow["Onvan"].ToString(),
                        Tp = DRow["Help"].ToString(),
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
                    ViewName = "Khata_View",
                    ViewData = this.ViewData
                };
            }
            catch (Exception ex)
            {
                if (!Center.RadCheckToken(DbConect, Request.Cookies["QuAnsBibel.OfficeWeb.ir"].ToString(), _LoginInfo))
                    return RedirectToPage("/Login", new { returnUrl = "KHata" });
                Center.ErrorLogSave(DbConect, ComText, _LoginInfo.Si, "مقادیر پایه", "OnGetHelpShow", ex.Message);
                ViewData["Switch"] = "Error";
                return new PartialViewResult
                {
                    ViewName = "Khata_View",
                    ViewData = this.ViewData
                };
            }
        }

        public IActionResult OnPostReturn(string PAGE = "HOME")
        {
            return RedirectToPage(PAGE);
        }
    }
}