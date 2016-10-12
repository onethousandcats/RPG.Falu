using RPG.Falu.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RPG.Falu.Web.Controllers
{
    public class SessionsController : Controller
    {
        private RpgModel _rpg = new RpgModel();

        public ActionResult Index()
        {
            return View(_rpg.Sessions.OrderByDescending(x => x.Date));
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Add(Session s)
        {
            Rpg.Instance.Add(s);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            return View(_rpg.Sessions.Find(Id));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(Session s)
        {
            Rpg.Instance.Update(s);
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int Id)
        {
            Rpg.Instance.RemoveSession(Id);
            return RedirectToAction("Index");
        }
    }
}