using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lots.Library
{
    public class Common
    {
        const string DefaultLanguage = "zh_CN";

        public static string GetDefaultLanguage { get { return DefaultLanguage; } }

        public static string GetResourceValue(string Key)
        {
            return GetResourceValue(Key, new HttpContextWrapper(HttpContext.Current));
        }

        public static bool CheckSupportLanguage(string Language)
        {
            string[] aLanguage = { "zh_cn", "zh_tw" };
            return !string.IsNullOrEmpty(Language) && aLanguage.Contains(Language.ToLower());
        }

        public static string GetResourceValue(string Key, HttpContextBase hc)
        {
            string Language = GetInitialLanguage(hc.Request, hc.Response);
            string sClassKey = string.Format("Chess.{0}", Language);
            return hc.GetGlobalResourceObject(sClassKey, Key) as string;
        }

        private static string GetInitialLanguage(HttpRequestBase Request, HttpResponseBase Reponse)
        {
            string Language = Request.RequestContext.RouteData.Values["Language"] as string;

            if (string.IsNullOrEmpty(Language) || !CheckSupportLanguage(Language))
            {
                Language = Trans(Request.UserLanguages[0], DefaultLanguage);
            }

            return Language;
        }

        private static string Trans(string BrowserLanguage, string DefaultLanguage)
        {
            BrowserLanguage = BrowserLanguage.ToUpper();
            string Language = DefaultLanguage;

            Dictionary<string, string> LanguageDict = new Dictionary<string, string>();
            LanguageDict.Add("ZH-CN", "zh_CN");
            LanguageDict.Add("ZH-CHS", "zh_CN");
            LanguageDict.Add("ZH-SG", "zh_CN");
            LanguageDict.Add("ZH-HK", "zh_TW");
            LanguageDict.Add("ZH-MO", "zh_TW");
            LanguageDict.Add("ZH-TW", "zh_TW");
            LanguageDict.Add("ZH-CHT", "zh_TW");

            if (LanguageDict.TryGetValue(BrowserLanguage, out Language))
            {

            }
            else if (BrowserLanguage.StartsWith("ZH"))
            {
                Language = "zh_CN";
            }
            //else if (BrowserLanguage.StartsWith("ID"))
            //{
            //    Language = "id";
            //}
            //else if (BrowserLanguage.StartsWith("TH"))
            //{
            //    Language = "th";
            //}
            //else if (BrowserLanguage.StartsWith("EN"))
            //{
            //    Language = "en";
            //}
            else
            {
                Language = DefaultLanguage;
            }

            return Language;
        }
    }
}