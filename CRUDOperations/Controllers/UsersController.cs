using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDOperations.Models;

namespace CRUDOperations.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            using (var user = new UsersEntities())
            {
                var users = user.Users.ToList().Select(x => new UsersViewModel
                {
                    UserName = x.UserName,
                    UserEmail = x.UserEmail,
                    UserId = x.UserId
                });
                return View(users);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UsersViewModel objuser)
        {
            var User = new User { UserName = objuser.UserName, UserEmail = objuser.UserEmail };
            using (var user = new UsersEntities())
            {
                user.Users.Add(User);
                user.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Int64? id)
        {
            var userentities = new UsersEntities();
            var user = userentities.Users.Find(id);
            UsersViewModel objuser = new UsersViewModel();
            objuser.UserEmail = user.UserEmail;
            objuser.UserName = user.UserName;
            objuser.UserId = user.UserId;
            return View(objuser);
        }

        [HttpPost]
        public ActionResult Edit(UsersViewModel objuser)
        {
            using (var user = new UsersEntities())
            {
                var oneuser = user.Users.Find(objuser.UserId);
                oneuser.UserEmail = objuser.UserEmail;
                oneuser.UserName = objuser.UserName;
                user.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(Int64? id)
        {
            UsersViewModel objuser = new UsersViewModel();
            using (var user = new UsersEntities())
            {
                var oneuser = user.Users.Find(id);
                objuser.UserName = oneuser.UserName;
                objuser.UserEmail = oneuser.UserEmail;
            }
            return View(objuser);
        }

        public ActionResult Delete(Int64? id)
        {
            UsersViewModel objuser = new UsersViewModel();
            using (var user = new UsersEntities())
            {
                var oneuser = user.Users.Find(id);
                objuser.UserName = oneuser.UserName;
                objuser.UserEmail = oneuser.UserEmail;
                objuser.UserId = oneuser.UserId;
            }
            return View(objuser);
        }

        [HttpPost]
        public ActionResult Delete(UsersViewModel objuser)
        {
            using (var user = new UsersEntities())
            {
                var oneuser = user.Users.Find(objuser.UserId);
                user.Users.Attach(oneuser);
                user.Entry(oneuser).State = System.Data.EntityState.Deleted;
                user.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
