using JXDevPlanner.Data;
using JXDevPlanner.Models;
using JXDevPlanner.Services;
using JXDevPlanner.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace JXDevPlanner.WebMVC.Controllers
{
    // TAKEN FROM THIS POST ON STACKOVERFLOW:
    //  https://stackoverflow.com/questions/31185694/how-can-i-get-identity-userid-in-the-controller-right-after-a-successful-login-r
    //  (Answer by Project Mayhem)
    public class UserHelper
    {
        public static string GetUserId()
        {
            var identity = (System.Security.Claims.ClaimsPrincipal)System.Threading.Thread.CurrentPrincipal;
            var principal = System.Threading.Thread.CurrentPrincipal as System.Security.Claims.ClaimsPrincipal;
            var userId = identity.Claims.Where(c => c.Type == System.Security.Claims.ClaimTypes.NameIdentifier).Select(c => c.Value).SingleOrDefault();
            return userId;
        }
    }

    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
            var svc = CreateRoleService();
            var model = svc.GetRoles();
            return View(model);
        }

        public ActionResult CreateRole()
        {
            var model = new RoleCreate();
            return View(model);
        }
        
        public ActionResult Delete(Guid id)
        {
            var model = new RoleDelete(CreateRoleService().GetRoleById(id));
            var svc = CreateRoleService();
            svc.DeleteRole(model);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteConfirm(Guid id)
        {
            var svc = CreateRoleService();
            return View(new RoleDelete(svc.GetRoleById(id)));
        }

        public ActionResult CreateByName(string name,int n) => Create(new RoleCreate { RoleName = name },n);
        public ActionResult Create(RoleCreate model,int n)
        {
            var svc = CreateRoleService();
            if (!ModelState.IsValid) return View(model);
            if (svc.CreateRole(model))
            {
                TempData["SaveResult"] = $"The Role \"{model.RoleName}\" was created successfuly.";
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult CreateAndAssign(Guid userID)
        {
            var model = new RoleCreateAndAssignModel(userID);
            return View(model);
        }

        public ActionResult CreateAndAssignFunc(Guid userID,string roleName)
        {
            var svc = CreateRoleService();
            var usvc = CreateUserRoleService();
            var model = new RoleCreate { RoleName = roleName };
            var b = svc.CreateRole(model);
            AbstractService.Context.SaveChanges();
            usvc.AssignRole(userID,svc.GetRoleById(model.RoleID));
            return RedirectToAction("ListUsers","Account",new { });
        }

        //public ActionResult Details(Guid id)
        //{
        //    var svc = CreateRoleService();
        //    RoleDetails model = new RoleDetails(svc.GetRoleById(id));
        //    model
        //}

        public ActionResult RemoveRoleFromUser(Guid userID)
        {
            var usvc = new AccountService(userID,GStorage.Data["UserManager"]);
            var rsvc = new RoleService(userID);
            var model = new RemoveRoleFromUserModel(userID);
            model.UserName = usvc.GetUserById(userID).UserName;
            return View(model);
        }

        public ActionResult RemoveRoleFromUserFunc(Guid userID,Guid roleID)
        {
            var svc = CreateUserRoleService();
            svc.UnassignRole(userID,roleID);
            return RedirectToAction("ListUsers","Account",new { });
        }

        public ActionResult AddRoleToUser(Guid userID)
        {
            var model = new AddRoleToUserModel(userID);
            model.UserName = new AccountService(Guid.Parse(UserHelper.GetUserId()),GStorage.Data["UserManager"]).GetUserById(userID).UserName;
            return View(model);
        }

        public ActionResult AddRoleToUserFunc(Guid userID,string roleID)
        {
            var svc = CreateUserRoleService();
            //throw new Exception($"USER = {userID} & ROLE = {roleID}");
            svc.AssignRole(userID,CreateRoleService().GetRoleById(Guid.Parse(roleID)));
            return RedirectToAction("ListUsers","Account",new { });
        }

        public ActionResult Edit(Guid id,string returnUrl)
        {
            var svc = CreateRoleService();
            var model = new RoleEdit(svc.GetRoleById(id),returnUrl);
            return View(model);
        }

        public UserRoleService CreateUserRoleService() => new UserRoleService(Guid.Parse(UserHelper.GetUserId()),GStorage.Data["UserManager"]);

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Edit(RoleEdit model)
        {
            var svc = CreateRoleService();
            if (!ModelState.IsValid) return View(model);
            if (svc.EditRole(model))
            {
                TempData["SaveResult"] = "The Role was successfully updated.";
                return Redirect(model.ReturnUrl);
            }
            return View(model);
        }

        public RoleService CreateRoleService() => new RoleService(Guid.Parse(UserHelper.GetUserId()));
    }
}