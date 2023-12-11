using QuAnsBibel.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace QuAnsBibel.Services
{
    public static class Center
    {
        public static string DbConect()
        {
            //System.Configuration.Assemblies()
            //System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]
            //            string cn = ConfigurationManager.ConnectionStrings["Scratchpad"].ConnectionString; //hier wordt de databasestring opgehaald

            return @"Data Source = 89.252.181.210\MSSQLSERVER2019; " +
                             " User ID = Officewe_Iran;" +
                             " Password = SunFlower#5511398193;" +
                             " Initial Catalog = officewe_QuAns;" +
                             " Connect Timeout=120;";

            //return @"Data Source = localhost;" +
            //                " User ID = Rad_Mng;" +
            //                " Password = 1;" +
            //                " Initial Catalog = Order;";

        }

        internal static bool RadCheckToken(string dbConect, string v, object loginInfo)
        {
            throw new NotImplementedException();
        }

        public static void DeleteIfExists(FileInfo file)
        {
            if (file.Exists)
                file.Delete();
        }
        public static string ChapName(string ID = "0", string Cooki = "0")
        {
            // اگر Cooki=0 باشد در متغیر ID سریال کاربر نوشته شده است در غیر اینصورت در متغیر ID متن ارتباط با دیتابیس نوشته شده است
            if (Cooki != "0")
            {
                var ComText = "EXEC [dbo].[Karbaran_IdToken] '" + Cooki.ToString() + "'";
                ID = RunGetReult(ID, ComText, "Si");
            };

            return "Print_" + ID + ".Pdf";
        }
        public static string ExcelName(string ID = "0", string Cooki = "0")
        {
            // اگر Cooki=0 باشد در متغیر ID سریال کاربر نوشته شده است در غیر اینصورت در متغیر ID متن ارتباط با دیتابیس نوشته شده است
            if (Cooki != "0")
            {
                var ComText = "EXEC [dbo].[Karbaran_IdToken] '" + Cooki.ToString() + "'";
                ID = RunGetReult(ID, ComText, "Si");
            };

            return "Excel_" + ID + ".xlsx";
        }
        public static void RunCommand(string DbConect, string comText)
        { // اجرای یک دستور کامند اس کیو ال
            using (SqlConnection SCon = new SqlConnection(DbConect))
            {
                SCon.Open();
                using (SqlCommand SCom = new SqlCommand(comText, SCon))
                    SCom.ExecuteNonQuery();

                SCon.Close();
            };
        }
        public static void ErrorLogSave(string DbConect, string comText, string Id_User, string Frm, string Prc, string Err)
        { // ذخیره خطا
            string CMD = "Exec [dbo].[ErrorLog_Save] '" + Id_User + "',N'" + Frm + "','" + Prc + "',N'" + comText.Replace("'", "|") + "','" + Err.Replace("'", "|") + "'";

            using (SqlConnection SCon = new SqlConnection(DbConect))
            {
                SCon.Open();
                using (SqlCommand SCom = new SqlCommand(CMD, SCon))
                    SCom.ExecuteNonQuery();

                SCon.Close();
            };
        }
        public static string RunGetReult(string DbConect, string comText, string Res)
        { // اجرای یک دستور اس کیو ال بابازگشت
            string Result = "";

            using (SqlConnection SCon = new SqlConnection(DbConect))
            {
                SCon.Open();
                using (SqlCommand SCom = new SqlCommand(comText, SCon))
                {
                    SqlDataReader RDR = SCom.ExecuteReader();
                    if (RDR.HasRows)
                    {
                        RDR.Read();
                        Result = RDR[Res].ToString();
                    }
                }
                SCon.Close();
            };

            return Result;
        }
        public static IdValuTp RunGetReult2Value(string DbConect, string comText, string ID, string VALUE)
        { // اجرای یک دستور اس کیو ال بابازگشت
            IdValuTp IVT = new IdValuTp();

            using (SqlConnection SCon = new SqlConnection(DbConect))
            {
                SCon.Open();
                using (SqlCommand SCom = new SqlCommand(comText, SCon))
                {
                    SqlDataReader RDR = SCom.ExecuteReader();
                    if (RDR.HasRows)
                    {
                        RDR.Read();
                        IVT.Id = RDR[ID].ToString();
                        IVT.Value = RDR[VALUE].ToString();
                    }
                }
                SCon.Close();
            };

            return IVT;
        }
        public static IdValuTp RunGetReult3Value(string DbConect, string comText, string ID, string VALUE, string TP)
        { // اجرای یک دستور اس کیو ال بابازگشت
            IdValuTp IVT = new IdValuTp();

            using (SqlConnection SCon = new SqlConnection(DbConect))
            {
                SCon.Open();
                using (SqlCommand SCom = new SqlCommand(comText, SCon))
                {
                    SqlDataReader RDR = SCom.ExecuteReader();
                    if (RDR.HasRows)
                    {
                        RDR.Read();
                        IVT.Id = RDR[ID].ToString();
                        IVT.Value = RDR[VALUE].ToString();
                        IVT.Tp = RDR[TP].ToString();
                    }
                }
                SCon.Close();
            };

            return IVT;
        }
        public static IdValuTp RunGetReult4Value(string DbConect, string comText, string ID, string VALUE, string TP, string REG)
        { // اجرای یک دستور اس کیو ال بابازگشت
            IdValuTp IVT = new IdValuTp();

            using (SqlConnection SCon = new SqlConnection(DbConect))
            {
                SCon.Open();
                using (SqlCommand SCom = new SqlCommand(comText, SCon))
                {
                    SqlDataReader RDR = SCom.ExecuteReader();
                    if (RDR.HasRows)
                    {
                        RDR.Read();
                        IVT.Id = RDR[ID].ToString();
                        IVT.Value = RDR[VALUE].ToString();
                        IVT.Tp = RDR[TP].ToString();
                        IVT.Reg = RDR[REG].ToString();
                    }
                }
                SCon.Close();
            };

            return IVT;
        }
        public static DataSet RunReport(string DbConect, string ComText)
        {//گرفتن یک گزارش از اس کیو ال
            DataSet DS = new DataSet();
            using (SqlDataAdapter SDA = new SqlDataAdapter(ComText, DbConect))
            {
                SDA.SelectCommand.CommandTimeout = 120;
                SDA.Fill(DS, "RES");
            }
            return DS;
        }

        public static void DateSegmant(string DbConect, DateSeg _Date)
        { // بازگرداندن اجزای تاریخ
            using (SqlConnection SCon = new SqlConnection(DbConect))
            {
                SCon.Open();
                using (SqlCommand SCom = new SqlCommand("EXEC [dbo].[GetDate]", SCon))
                {
                    SqlDataReader RDR = SCom.ExecuteReader();
                    RDR.Read();
                    _Date.ToDay = RDR["ToDay"].ToString();
                    _Date.ToMonth = RDR["ToMonth"].ToString();
                    _Date.Year = RDR["ThisYear"].ToString();
                    _Date.Month = RDR["ThisMonth"].ToString();
                    _Date.Day = RDR["ThisDay"].ToString();
                    _Date.Time = RDR["ThisTime"].ToString();
                    _Date.Hour = RDR["ThisHH"].ToString();
                    _Date.Min = RDR["ThisMM"].ToString();
                    _Date.Sec = RDR["ThisSS"].ToString();
                   // _Date.MonthName = MonthName(RDR["ThisMonth"].ToString());

                }
                SCon.Close();
            };
        }
        public static string MonthName(string MN)
        {
            string MNAME = MN.Replace("01", "فروردین").Replace("02", "اردیبهشت").Replace("03", "خرداد").Replace("04", "تیر").Replace("05", "مرداد").Replace("06", "شهریور").Replace("07", "مهر").Replace("08", "آبان").Replace("09", "آذر").Replace("10", "دی").Replace("11", "بهمن").Replace("12", "اسفند");
            return MNAME;
        }

        public static bool RadCheckToken(string DbConect, string Cooki, LoginInfo _LoginInfo)
        { // کنترل اینکه آیا کاربر لاگین کرده است؟
            _LoginInfo.Token = Cooki.ToString();

            var ComText = "EXEC [dbo].[CheckToken] '" + _LoginInfo.Token + "'";
            try
            {
                using (SqlConnection SCon = new SqlConnection(DbConect))
                {
                    SCon.Open();
                    using (SqlCommand SCom = new SqlCommand(ComText, SCon))
                    {
                        using (SqlDataReader RDR = SCom.ExecuteReader())
                        {
                            RDR.Read();
                            if (RDR["Knd"].ToString() != "0" && RDR["Active"].ToString() == "1")
                            {
                             //   _LoginInfo.Active = RDR["Active"].ToString();
                                _LoginInfo.Si = RDR["Si"].ToString();
                                _LoginInfo.Name = RDR["UsrName"].ToString();
                                return true;
                            }
                            else
                            {
                             //   _LoginInfo.Active = "0";
                                return false;
                            }
                        };
                    };
                   // SCon.Close();
                };
            }
            catch
            {
                _LoginInfo.Si = "0";
                return false;
            };

        }
        public static string CommaAdd(string number)
        {
            // ابتدا اگر کاما دارد برداشته 
            // اعشار کنترل شود
            // بروی صحیح کاما گذاری شود
            number = CommaClear(number);
            if (number == "0")
                number = "0";

            int i;
            string NPosetiv = "0";
            string N = "0";
            string D = "0";
            string NumberStrRet;
            string Manfi = "";

        
            NPosetiv = (Math.Abs(Convert.ToDecimal(number))).ToString();

            if (number != NPosetiv)
                Manfi = "-";

            int position = NPosetiv.IndexOf(".");
            if (position != -1)
            {
                N = Left(NPosetiv, position);
                D = Ashar(NPosetiv, position);
            }
            else
                N = NPosetiv;


            i = N.Length;
            if (i <= 3)
                NumberStrRet = N;
            else
                NumberStrRet = N.Substring(N.Length - 3, 3);

            while (i > 3)
            {
                i -= 3;
                N = N.Substring(0, i);
                if (i < 3)
                    NumberStrRet = N + "," + NumberStrRet;
                else
                    NumberStrRet = N.Substring(N.Length - 3, 3) + "," + NumberStrRet;
            }

            NumberStrRet = Manfi + NumberStrRet;
            if (position != -1)
                if (D != "0")
                    NumberStrRet = NumberStrRet + "." + D;

            return NumberStrRet;
        }
        public static string Left(this string value, int maxLength)
        { // کاراکترهای سمت چپ یک عبارت
            if (string.IsNullOrEmpty(value)) return value;
            maxLength = Math.Abs(maxLength);

            return (value.Length <= maxLength
                    ? value
                    : value.Substring(0, maxLength)
                    );
        }
        public static string Right(this string value, int maxLength)
        {// کاراکترهای سمت راست یک عبارت
            if (string.IsNullOrEmpty(value)) return value;
            maxLength = Math.Abs(maxLength);

            return (value.Length <= maxLength ? value : value.Substring(value.Length - maxLength));
        }
        public static string Ashar(this string value, int Pos)
        {// مقدار تصحیح شده قسمت اعشاری یک عدد همه صفرهای سمت راست پاک شود
            if (String.IsNullOrEmpty(value)) return value;

            value = value.Length <= Pos ? value : value.Substring(Pos + 1);

            while (Right(value, 1) == "0")
                value = Left(value, value.Length - 1);

            if (value == "")
                value = "0";

            return value;
        }
        public static string CommaClear(string NUMBER)
        {
            if (NUMBER == null)
                NUMBER = "";
            NUMBER = NUMBER.Replace(" ", "");
            if (NUMBER == "")
                return "0";
            else
            {
                NUMBER = EnglishNumber(NUMBER);
                NUMBER = NUMBER.Replace(",", "");
                return NUMBER;
            }
        }
        public static string TrimTxt(string text)
        {
            if (text == "" || text == null)
                return "";
            else
                return text.Trim();
        }
        public static string ReverseString(string s)
        {
            char[] array = new char[s.Length];
            int forward = 0;
            for (int i = s.Length - 1; i >= 0; i--)
                array[forward++] = s[i];

            return new string(array);
        }
        public static string ReverseDate(string Date)
        {
            return Date.Substring(8, 2) + "/" + Date.Substring(5, 2) + "/" + Date.Substring(0, 4);
        }
       public static string EnglishNumber(string NUMBER="1234567890")
       {
            if (NUMBER == null)
                NUMBER = "";
             return NUMBER.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");
        }
    }
}
