using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using QuAnsBibel.Services;
using QuAnsBibel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.IO;

namespace QuAnsBibel.Pages
{
    public class HomeModel : PageModel

    {
        private readonly string DbConect = Center.DbConect();
        string ComText = "";
        public IdValuTp _IdValuTp;
        public Rep10 _Report;

//        public List<ListForm> Form_List;
        public LoginInfo _LoginInfo = new LoginInfo();
        public FormSetup _FormSetup;
        public List<IdValuTp> Last_Forms;

        private Microsoft.AspNetCore.Hosting.IWebHostEnvironment _hostingEnvironment;
        public HomeModel(Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostingEnvironment)
        {// مسیر روت برنامه
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult OnGet()
        {
            _FormSetup = new FormSetup()
            {
                Name = "HOME",
                Title = "این خانه خانه توست",
                Header = "من نور جهان هستم، کسی‌که از من پیروی كند در تاریكی سرگردان نخواهد شد، بلكه نور حیات را خواهد داشت.",//DRow["Header"].ToString(),
                Footer = "درپناه خدا باشید",
                Matn_A = "",
                Matn_B = "",
            };

            try
            {
                ComText = "EXEC [dbo].[Form_HFShow] '1'";
                //using (var DS = Center.RunReport(DbConect, ComText))
                //{
                //    DataRow DRow = DS.Tables["RES"].Rows[0];
                //    _FormSetup = new FormSetup()
                //    {
                //        Name = DRow["NameForm"].ToString(),
                //        Title = DRow["Onvan"].ToString(),
                //        Header = "من نور جهان هستم، کسی‌که از من پیروی كند در تاریكی سرگردان نخواهد شد، بلكه نور حیات را خواهد داشت.",//DRow["Header"].ToString(),
                //        Footer = DRow["Footer"].ToString(),
                //        Matn_A = DRow["MatnA"].ToString(),
                //        Matn_B = DRow["MatnB"].ToString(),
                //    };
                //}

                Report();

                    return Page();
            }
            catch (Exception ex)
            {
                Center.ErrorLogSave(DbConect, ComText, _LoginInfo.Si, "خانه", "OnGet", ex.Message);
                return RedirectToPage("/Khata", new { returnUrl = "Home" });
            }
        }


        private void Report()
        {
            /*
            ComText = "Exec [dbo].[Report_Home] '" + _LoginInfo.Si + "','" + _LoginInfo.Knd + "'";
            using (var DS = Center.RunReport(DbConect, ComText))
            {
                DataRow DRow = DS.Tables["RES"].Rows[0];

                _Report = new Rep()
                {
                    Rep_10 = DRow["Rep_10"].ToString(),
                    Rep_11 = DRow["Rep_11"].ToString(),
                    Rep_12 = DRow["Rep_12"].ToString(),
                    Rep_13 = DRow["Rep_13"].ToString(),
                    Rep_14 = DRow["Rep_14"].ToString(),
                    Rep_15 = DRow["Rep_15"].ToString(),
                    Rep_16 = DRow["Rep_16"].ToString(),
                    Rep_17 = DRow["Rep_17"].ToString(),
                    Rep_18 = DRow["Rep_18"].ToString(),
                    Rep_19 = DRow["Rep_19"].ToString(),
                    Rep_20 = DRow["Rep_20"].ToString(),
                    Rep_21 = DRow["Rep_21"].ToString(),
                    Rep_22 = DRow["Rep_22"].ToString(),
                    Rep_23 = DRow["Rep_23"].ToString(),
                    Rep_24 = DRow["Rep_24"].ToString(),
                    Rep_25 = DRow["Rep_25"].ToString(),
                    Rep_26 = DRow["Rep_26"].ToString(),
                    Rep_27 = DRow["Rep_27"].ToString(),
                    Rep_28 = DRow["Rep_28"].ToString(),
                    Rep_29 = DRow["Rep_29"].ToString(),
                    Rep_30 = DRow["Rep_30"].ToString(),
                    Rep_Tp = DRow["Rep_Tp"].ToString(),
                };
            
            }
            ViewData["Switch"] = "KND_" + _LoginInfo.Knd;
            if (_LoginInfo.Knd == "2" || _LoginInfo.Knd == "6" || _LoginInfo.Knd == "7")
            {
                ViewData["Switch"] = "KND_267";
            }
    */
            ViewData["Switch"] = "KND";
        }

    }
}