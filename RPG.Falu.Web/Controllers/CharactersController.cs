using RPG.Falu.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace RPG.Falu.Web.Controllers
{
    public class CharactersController : Controller
    {
        private RpgModel _rpg = new RpgModel();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Sheet(int Id)
        {
            return PartialView("_Sheet", new CharacterViewModel(Id));
        }
    }
}