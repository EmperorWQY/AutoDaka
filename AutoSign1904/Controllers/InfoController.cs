using Microsoft.AspNetCore.Mvc;
using AutoSign1904.DataTransferModel;
using AutoSign1904.Models;
using Microsoft.AspNetCore.Authorization;

namespace AutoSign1904.Controllers
{
    [AllowAnonymous]
    public class InfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddInfo(InfoModel model)
        {
            if (model.Usr != "" && model.Pwd != "")
            {
                try
                {
                    var ctx = new db_signContext();
                    var j = new J();
                    j.Usr = model.Usr;
                    j.Pwd = model.Pwd;
                    ctx.Js.Add(j);
                    ctx.SaveChanges();
                    ViewData["error"] = "成功";
                }
                catch (Exception)
                {
                     ViewData["error"] = "数据库异常";
                }
            }
            else
                ViewData["error"] = "没有输入值";
            return View("Index");
        }
    }
}
