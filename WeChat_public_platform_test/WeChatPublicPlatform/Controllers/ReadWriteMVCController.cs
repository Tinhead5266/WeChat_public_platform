using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeChatPublicPlatform.Controllers
{
    /// <summary>
    /// 包含读写的MVC控制器
    /// </summary>
    public class ReadWriteMVCController : Controller
    {
        // GET: ReadWriteMVC
        public ActionResult Index()
        {
            return View();
        }

        // GET: ReadWriteMVC/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReadWriteMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReadWriteMVC/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReadWriteMVC/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReadWriteMVC/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReadWriteMVC/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReadWriteMVC/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}