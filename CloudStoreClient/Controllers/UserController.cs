using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CloudStoreClient.Helper;
using ServMan.ApiV1.Models;

namespace CloudStoreClient.Controllers
{
    public class UserController : Controller
    {
        readonly Config _cfg = new Config();

        //
        // GET: /User/

        public ActionResult Index()
        {
            var client = new HttpClientHelper(_cfg.UserId, _cfg.Secret, _cfg.OrganizationId);
            var usrList = client.DoGet<IEnumerable<UserListItem>>(new Uri(_cfg.ApiUrlBase, "User"));
            return View("List", usrList);
        }

        //
        // GET: /User/Details/5

        public ActionResult Details(Guid id)
        {
            var client = new HttpClientHelper(_cfg.UserId, _cfg.Secret, _cfg.OrganizationId);
            var usr = client.DoGet<User>(new Uri(_cfg.ApiUrlBase, "User/" + id));
            return View("Details", usr);
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            var user = new User { };
            return View("Create", user);
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                // TODO: Add insert logic here
                var client = new HttpClientHelper(_cfg.UserId, _cfg.Secret, _cfg.OrganizationId);
                client.DoPost(new Uri(_cfg.ApiUrlBase, "User"), user);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Create", user);
            }
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(Guid id)
        {
            var client = new HttpClientHelper(_cfg.UserId, _cfg.Secret, _cfg.OrganizationId);
            var usr = client.DoGet<User>(new Uri(_cfg.ApiUrlBase, "User/" + id));
            return View("Edit", usr);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                // TODO: Add insert logic here
                var client = new HttpClientHelper(_cfg.UserId, _cfg.Secret, _cfg.OrganizationId);
                client.DoPut(new Uri(_cfg.ApiUrlBase, "User"), user);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Edit", user);
            }
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(Guid id)
        {
            var client = new HttpClientHelper(_cfg.UserId, _cfg.Secret, _cfg.OrganizationId);
            var usr = client.DoGet<User>(new Uri(_cfg.ApiUrlBase, "User/" + id));
            return View("Delete", usr);
        }

        //
        // POST: /User/Delete/5

        [HttpPost]
        public ActionResult Delete(User user)
        {
            try
            {
                // TODO: Add insert logic here
                var client = new HttpClientHelper(_cfg.UserId, _cfg.Secret, _cfg.OrganizationId);
                client.DoDelete(new Uri(_cfg.ApiUrlBase, "User/" + user.Id));
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Delete", user);
            }
        }
    }
}
