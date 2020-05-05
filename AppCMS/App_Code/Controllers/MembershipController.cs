using AppCMS.Models;
using Umbraco.Web.Mvc;
using Umbraco.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AppCMS.Controllers
{
    public class MembershipController : Umbraco.Web.Mvc.SurfaceController
    {

        public const string PARTIAL_VIEW_FOLDER = "~/Views/Partials/";

        [HttpGet]
        [ActionName("MemberLogin")]
        public ActionResult Index()
        {
            return PartialView(PARTIAL_VIEW_FOLDER + "LoginForm.cshtml", new MemberLoginViewModel());
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return Redirect("/");
        }

        [HttpPost]
        [ActionName("MemberLogin")]
        public ActionResult Validate(MemberLoginViewModel model)
        {

            if (Membership.ValidateUser(model.Login, model.Password))
            {

                FormsAuthentication.SetAuthCookie(model.Login, model.RememberMe);
                //return RedirectToCurrentUmbracoPage();
                return Redirect("/");

            }

            TempData["Status"] = "Invalid Log-in Credentials";
            //return RedirectToCurrentUmbracoPage();
            return Redirect("/");

        }

        [HttpGet]
        [ActionName("Signup")]
        public ActionResult SignupMember()
        {
            //return PartialView(PARTIAL_VIEW_FOLDER + "SignUp.cshtml", new SignupNewMemberModel());
            return PartialView(PARTIAL_VIEW_FOLDER + "MemberSignUp.cshtml");
        }
         
        
        [HttpPost]
        [ActionName("Signup")]
        public ActionResult SignupMember(SignupNewMemberModel model)
        {
            
            var memberService = Services.MemberService;

            if (memberService.GetByEmail(model.Email) != null)
            {
                ModelState.AddModelError("", "Member already exists!");
            }

            var newMember = memberService.CreateMemberWithIdentity(model.Email, model.Email, model.Name, "Member");

            memberService.Save(newMember);

            memberService.SavePassword(newMember, model.Password);

            //return RedirectToCurrentUmbracoPage();
            return Redirect("/");

        }
        
    }
}