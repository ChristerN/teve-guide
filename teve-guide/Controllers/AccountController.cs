using teve_guide.Data;
using teve_guide.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace teve_guide.Controllers
{
    public class AccountController : Controller
    {
        DbOperations db = new DbOperations();
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM model, string ReturnUrl)
        {
            if (ModelState.IsValid)//kollar om något har fyllts i i rutorna för user o pass
            {


                if (db.CheckUserCredentials(model.Username, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false); //Skapar en login cookie som inte är persisten. Den försvinner när browsern stängs.
                    return Redirect(ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Felaktigt användarnamn eller lösenord.");
                }

            }
            return View();


        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "tv_shows");
        }
    }


}