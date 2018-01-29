using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lots.Models.Chess
{
    public class SlotsChess
    {
        private HttpContextBase hc;

        public SlotsChess()
        {
            hc = new HttpContextWrapper(HttpContext.Current);
        }

        public SlotsChess(HttpContextBase _hc)
        {
            hc = _hc;
        }

        public IEnumerable<string> chessSlots { set; get; }
        [JsonIgnore]
        public int R1 { set; get; }
        [JsonIgnore]
        public int t1 { set; get; }
        [JsonIgnore]
        public int t2 { set; get; }
        [JsonIgnore]
        public int t3 { set; get; }
        [JsonIgnore]
        public int t4 { set; get; }
        [JsonIgnore]
        public int t5 { set; get; }
        [JsonIgnore]
        public int t6 { set; get; }
        [JsonIgnore]
        public int t7 { set; get; }
        [JsonIgnore]
        public int t8 { set; get; }
        [JsonIgnore]
        public int t9 { set; get; }
        [JsonIgnore]
        public int t10 { set; get; }
        [JsonIgnore]
        public int t11 { set; get; }
        [JsonIgnore]
        public int t12 { set; get; }
        [JsonIgnore]
        public int t13 { set; get; }
        [JsonIgnore]
        public int t14 { set; get; }
        [JsonIgnore]
        public int t15 { set; get; }
        [JsonIgnore]
        public int t16 { set; get; }
        [JsonIgnore]
        public int t17 { set; get; }
        [JsonIgnore]
        public int t18 { set; get; }
        [JsonIgnore]
        public int t19 { set; get; }
        [JsonIgnore]
        public int t20 { set; get; }
        [JsonIgnore]
        public int t21 { set; get; }

        public string Result1
        {
            get
            {
                bool t1_temp = t1 <= 7;
                string sKey = string.Format("R1_{0}{1}", R1, t1_temp ? "Y" : "N");
                return Lots.Library.Common.GetResourceValue(sKey);
            }
        }

        public string Result2
        {
            get
            {
                int t1_temp = t1 <= 7 ? 1 : 0;
                int t2_temp = t2 <= 7 ? 1 : 0;
                int t3_temp = t3 <= 7 ? 1 : 0;
                string sKey = string.Format("Event{0}_{1}_{2}", t1_temp, t2_temp, t3_temp);
                return Lots.Library.Common.GetResourceValue(sKey);
            }
        }

        public string Result3
        {
            get
            {
                string t4_temp = t4 <= 7 ? "Y" : "N";
                string sKey = string.Format("t4_{0}", t4_temp);
                return Lots.Library.Common.GetResourceValue(sKey);
            }
        }

        public string Result4
        {
            get
            {
                string t5_temp = t5 <= 7 ? "Y" : "N";
                string sKey = string.Format("t5_{0}", t5_temp);
                return Lots.Library.Common.GetResourceValue(sKey);
            }
        }

        public string Result5
        {
            get
            {
                string t6_temp = t6 <= 7 ? "Y" : "N";
                string sKey = string.Format("t6_{0}", t6_temp);
                return Lots.Library.Common.GetResourceValue(sKey);
            }
        }
        //春
        public string Result6
        {
            get
            {
                string sKey = string.Format("FortuneType{0}", t7);
                return Lots.Library.Common.GetResourceValue(sKey);
            }
        }
        //夏
        public string Result7
        {
            get
            {
                string sKey = string.Format("FortuneType{0}", t8);
                return Lots.Library.Common.GetResourceValue(sKey);
            }
        }

        //秋
        public string Result8
        {
            get
            {
                string sKey = string.Format("FortuneType{0}", t9);
                return Lots.Library.Common.GetResourceValue(sKey);
            }
        }

        //冬
        public string Result9
        {
            get
            {
                string sKey = string.Format("FortuneType{0}", t10);
                return Lots.Library.Common.GetResourceValue(sKey);
            }
        }

        //北
        public string Result10
        {
            get
            {
                string sKey = string.Format("Benefactor{0}", t15);
                return Lots.Library.Common.GetResourceValue(sKey);
            }
        }

        //西
        public string Result11
        {
            get
            {
                string sKey = string.Format("Benefactor{0}", t14);
                return Lots.Library.Common.GetResourceValue(sKey);
            }
        }

        //身邊
        public string Result12
        {
            get
            {
                string sKey = string.Format("Benefactor{0}", t13);
                return Lots.Library.Common.GetResourceValue(sKey);
            }
        }

        //東
        public string Result13
        {
            get
            {
                string sKey = string.Format("Benefactor{0}", t11);
                return Lots.Library.Common.GetResourceValue(sKey);
            }
        }

        //南
        public string Result14
        {
            get
            {
                string sKey = string.Format("Benefactor{0}", t12);
                return Lots.Library.Common.GetResourceValue(sKey);
            }
        }

        public string Result15
        {
            get
            {
                string sKey = string.Format("t1_{0}", t1);
                return Lots.Library.Common.GetResourceValue(sKey);
            }
        }

        public string Result16
        {
            get
            {
                int t16_temp = t16 <= 7 ? 1 : 0;
                int t17_temp = t17 <= 7 ? 1 : 0;
                int t18_temp = t18 <= 7 ? 1 : 0;
                int t19_temp = t19 <= 7 ? 1 : 0;
                int t20_temp = t20 <= 7 ? 1 : 0;
                int t21_temp = t21 <= 7 ? 1 : 0;

                string sKey = string.Format("Suggest{0}_{1}_{2}_{3}_{4}_{5}", t16_temp, t17_temp, t18_temp, t19_temp, t20_temp, t21_temp);
                return Lots.Library.Common.GetResourceValue(sKey);
            }
        }
    }

    public class ContactUsData
    {
        [Required(ErrorMessage = "Name")]
        public string Username { get; set; }
        [Required(ErrorMessage = "E-Mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-Mail")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "E-Mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Content")]
        public string ContactContent { get; set; }
    }
}