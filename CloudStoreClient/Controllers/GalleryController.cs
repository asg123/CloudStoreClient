using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CloudStoreClient.Helper;
using ServMan.ApiV1.Models;

namespace CloudStoreClient.Controllers
{
    public class GalleryController : Controller
    {
        readonly Config _cfg = new Config();

        public ActionResult Index()
        {
            var client = new HttpClientHelper(_cfg.UserId, _cfg.Secret, _cfg.OrganizationId);
            var list = client.DoGet<IEnumerable<GalleryListItem>>(new Uri(_cfg.ApiUrlBase, "Gallery"));
            TempData["imgbase"] = _cfg.ImgUrlBase;
            return View("List", list);
        }

        public ActionResult Details(Guid id)
        {
            var client = new HttpClientHelper(_cfg.UserId, _cfg.Secret, _cfg.OrganizationId);
            var g = client.DoGet<Gallery>(new Uri(_cfg.ApiUrlBase, "Gallery/" + id));
            TempData["imgbase"] = _cfg.ImgUrlBase;
            return View("Details", g);
        }

    }
}
