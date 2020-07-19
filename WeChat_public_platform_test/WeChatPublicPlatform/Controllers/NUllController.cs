using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WeChatPublicPlatform.Controllers
{
    /// <summary>
    /// 空控制器
    /// </summary>
    public class NUllController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}