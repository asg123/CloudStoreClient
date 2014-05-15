using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CloudStoreClient.Helper;
using ServMan.ApiV1.Models;

namespace CloudStoreClient.Controllers
{
    public class OrganizationController : Controller
    {
        readonly Config _cfg = new Config();

        //
        // GET: /Organization/

        public ActionResult Index()
        {
            var client = new HttpClientHelper(_cfg.UserId, _cfg.Secret, _cfg.OrganizationId);
            var usrList = client.DoGet<IEnumerable<OrganizationListItem>>(new Uri(_cfg.ApiUrlBase, "Organization"));
            return View("List", usrList);
        }

        //
        // GET: /Organization/Details/5

        public ActionResult Details(Guid id)
        {
            var client = new HttpClientHelper(_cfg.UserId, _cfg.Secret, _cfg.OrganizationId);
            var usr = client.DoGet<Organization>(new Uri(_cfg.ApiUrlBase, "Organization/" + id));
            return View("Details", usr);
        }

        //
        // GET: /Organization/Create

        public ActionResult Create()
        {
            var Organization = new Organization { };
            return View("Create", Organization);
        }

        //
        // POST: /Organization/Create

        [HttpPost]
        public ActionResult Create(Organization organization)
        {
            try
            {
                // TODO: Add insert logic here
                var client = new HttpClientHelper(_cfg.UserId, _cfg.Secret, _cfg.OrganizationId);
                client.DoPost(new Uri(_cfg.ApiUrlBase, "Organization"), organization);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Create", organization);
            }
        }

        //
        // GET: /Organization/Edit/5

        public ActionResult Edit(Guid id)
        {
            var client = new HttpClientHelper(_cfg.UserId, _cfg.Secret, _cfg.OrganizationId);
            var usr = client.DoGet<Organization>(new Uri(_cfg.ApiUrlBase, "Organization/" + id));
            return View("Edit", usr);
        }

        //
        // POST: /Organization/Edit/5

        [HttpPost]
        public ActionResult Edit(Organization organization)
        {
            try
            {
                // TODO: Add insert logic here
                var client = new HttpClientHelper(_cfg.UserId, _cfg.Secret, _cfg.OrganizationId);
                client.DoPut(new Uri(_cfg.ApiUrlBase, "Organization"), organization);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Edit", organization);
            }
        }

    }
}
