using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lots.Library;
using System.Text;

namespace Lots.Controllers
{
    [SetPageResource]
    public class ChessController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = Common.GetResourceValue("AppName") + " - " + Common.GetResourceValue("History");
            ViewBag.HistoryContent1 = Common.GetResourceValue("HistoryContent1");
            ViewBag.HistoryContent2 = Common.GetResourceValue("HistoryContent2");

            return View();
        }

        public ActionResult Fortune()
        {
            ViewBag.Title = Common.GetResourceValue("AppName") + " - " + Common.GetResourceValue("Fortune");
            Dictionary<string, string> GlobalResource = new Dictionary<string, string>();
            string[] sLan = new string[] { "SelectCategory", "Question1", "Note1", "Note3", "Specific", "Note2", "Submit1", "Submit2", "spring", "summer", "autumn", "winter", "east", "south", "west", "north", "Surroundings", "Opportunity", "Environment", "Social" };

            foreach (var lanKey in sLan)
            {
                GlobalResource.Add(lanKey, Common.GetResourceValue(lanKey));
            }

            for (int i = 1; i <= 7; i++)
            {
                GlobalResource.Add("select_01_" + i, Common.GetResourceValue("select_01_" + i));
            }

            for (int i = 1; i <= 8; i++)
            {
                GlobalResource.Add("R1_" + i, Common.GetResourceValue("R1_" + i));
            }

            for (int i = 1; i <= 8; i++)
            {
                GlobalResource.Add("FortuneSub" + i, Common.GetResourceValue("FortuneSub" + i));
            }

            for (int i = 97; i <= 110; i++)
            {
                string A = Convert.ToChar(i).ToString();
                GlobalResource.Add(A, Common.GetResourceValue(A));
            }

            ViewBag.i18n = Newtonsoft.Json.JsonConvert.SerializeObject(GlobalResource);
            return View();
        }

        [HttpPost]
        public ActionResult FortuneResult(string jsoncallback, int R1, int[] DrawLots)
        {
            Dictionary<int, int> DicDrawLots = new Dictionary<int, int>();

            foreach (var Lot in DrawLots)/*Check Duplicate*/
            {
                if (!DicDrawLots.ContainsKey(Lot) && Lot < 32 && Lot >= 0)
                {
                    DicDrawLots.Add(Lot, Lot);
                }
            }

            List<string> chessSlots = new List<string> { "a1", "b1", "b2", "c1", "c2", "d1", "d2", "e1", "e2", "f1", "f2", "g1", "g2", "g3", "g4", "g5", "h1", "i1", "i2", "j1", "j2", "k1", "k2", "l1", "l2", "m1", "m2", "n1", "n2", "n3", "n4", "n5" };
            string[] finalchess = new string[32];

            for (int i = 0; i < chessSlots.Count; i++)
            {
                string TempChessLot = chessSlots[i];
                Random rndChess = new Random(Guid.NewGuid().GetHashCode());
                int random_num = rndChess.Next(0, chessSlots.Count);
                chessSlots[i] = chessSlots[random_num];
                chessSlots[random_num] = TempChessLot;
            }

            int idxfinalchess = 0;
            foreach (var DrawLot in DicDrawLots)
            {
                finalchess[idxfinalchess] = chessSlots[DrawLot.Key];
                idxfinalchess++;
            }

            Lots.Models.Chess.SlotsChess oSlotsChess = new Models.Chess.SlotsChess();
            oSlotsChess.chessSlots = finalchess;
            oSlotsChess.R1 = R1;
            Random rnd = new Random();
            oSlotsChess.t1 = Convert.ToInt32(finalchess[0].ToCharArray()[0]) - 96;
            oSlotsChess.t2 = Convert.ToInt32(finalchess[1].ToCharArray()[0]) - 96;
            oSlotsChess.t3 = Convert.ToInt32(finalchess[2].ToCharArray()[0]) - 96;
            oSlotsChess.t4 = Convert.ToInt32(finalchess[3].ToCharArray()[0]) - 96;
            oSlotsChess.t5 = Convert.ToInt32(finalchess[4].ToCharArray()[0]) - 96;
            oSlotsChess.t6 = Convert.ToInt32(finalchess[5].ToCharArray()[0]) - 96;
            oSlotsChess.t7 = Convert.ToInt32(finalchess[6].ToCharArray()[0]) - 96;
            oSlotsChess.t8 = Convert.ToInt32(finalchess[7].ToCharArray()[0]) - 96;
            oSlotsChess.t9 = Convert.ToInt32(finalchess[8].ToCharArray()[0]) - 96;
            oSlotsChess.t10 = Convert.ToInt32(finalchess[9].ToCharArray()[0]) - 96;
            oSlotsChess.t11 = Convert.ToInt32(finalchess[10].ToCharArray()[0]) - 96;
            oSlotsChess.t12 = Convert.ToInt32(finalchess[11].ToCharArray()[0]) - 96;
            oSlotsChess.t13 = Convert.ToInt32(finalchess[12].ToCharArray()[0]) - 96;
            oSlotsChess.t14 = Convert.ToInt32(finalchess[13].ToCharArray()[0]) - 96;
            oSlotsChess.t15 = Convert.ToInt32(finalchess[14].ToCharArray()[0]) - 96;
            oSlotsChess.t16 = Convert.ToInt32(finalchess[15].ToCharArray()[0]) - 96;
            oSlotsChess.t17 = Convert.ToInt32(finalchess[16].ToCharArray()[0]) - 96;
            oSlotsChess.t18 = Convert.ToInt32(finalchess[17].ToCharArray()[0]) - 96;
            oSlotsChess.t19 = Convert.ToInt32(finalchess[18].ToCharArray()[0]) - 96;
            oSlotsChess.t20 = Convert.ToInt32(finalchess[19].ToCharArray()[0]) - 96;
            oSlotsChess.t21 = Convert.ToInt32(finalchess[20].ToCharArray()[0]) - 96;

            string content = jsoncallback + "(" + Newtonsoft.Json.JsonConvert.SerializeObject(oSlotsChess) + ");";

            return new ContentResult() { Content = content, ContentEncoding = System.Text.Encoding.UTF8, ContentType = "application/javascript" };
        }

        public ActionResult Contact()
        {
            ViewBag.Title = Common.GetResourceValue("AppName") + " - " + Common.GetResourceValue("Contact");
            ViewBag.Send = Common.GetResourceValue("Send");
            ViewBag.ContactContent = Common.GetResourceValue("ContactContent");
            ViewBag.Email = Common.GetResourceValue("Email");
            ViewBag.Username = Common.GetResourceValue("Username");

            return View();
        }

        [HttpPost]
        public ActionResult SubmitContact(string jsoncallback, Models.Chess.ContactUsData oContactUsData)
        {
            int ErrCode = 0;
            StringBuilder ErrMsg = new StringBuilder();

            if (ModelState.IsValid)
            {
                string InfoLogFileName = AppDomain.CurrentDomain.BaseDirectory + @"Logs\Contact_{0}.txt";
                StringBuilder ContactUsSB = new StringBuilder();
                ContactUsSB.AppendLine(oContactUsData.Username);
                ContactUsSB.AppendLine("===================");
                ContactUsSB.AppendLine(oContactUsData.Email);
                ContactUsSB.AppendLine("===================");
                ContactUsSB.AppendLine(oContactUsData.ContactContent);

                IBCFile.Logger.Log(String.Format(InfoLogFileName, DateTime.Now.ToString("yyyyMMdd")), ContactUsSB.ToString());
            }

            if (!ModelState.IsValid)
            {
                ErrCode = 1;

                foreach (var i in ModelState.Values)
                {
                    foreach (var j in i.Errors)
                    {
                        ErrMsg.AppendLine("*" + j.ErrorMessage);
                    }

                }
            }

            string content = jsoncallback + "(" + Newtonsoft.Json.JsonConvert.SerializeObject(new { ErrCode = ErrCode, ErrMsg = ErrMsg.ToString() }) + ");";
            return new ContentResult() { Content = content, ContentEncoding = System.Text.Encoding.UTF8, ContentType = "application/javascript" };
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class SetPageResource : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var viewBag = filterContext.Controller.ViewBag;
            viewBag.History = Common.GetResourceValue("History", filterContext.HttpContext);
            viewBag.Fortune = Common.GetResourceValue("Fortune", filterContext.HttpContext);
            viewBag.Contact = Common.GetResourceValue("Contact", filterContext.HttpContext);
            viewBag.AppName = Common.GetResourceValue("AppName", filterContext.HttpContext);
            viewBag.SiteDescription = Common.GetResourceValue("SiteDescription", filterContext.HttpContext);
            string Language = filterContext.HttpContext.Request.RequestContext.RouteData.Values["Language"] as string;
            viewBag.Language = Language;

            base.OnActionExecuting(filterContext);
        }
    }
}
