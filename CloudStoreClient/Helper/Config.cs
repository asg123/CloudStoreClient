using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CloudStoreClient.Helper
{
    public class Config
    {
        public Guid UserId = new Guid(ConfigurationManager.AppSettings["UserId"]);
        public string Secret = ConfigurationManager.AppSettings["Secret"];
        public Guid OrganizationId = new Guid(ConfigurationManager.AppSettings["OrganizationId"]);
        public Uri ApiUrlBase = new Uri(ConfigurationManager.AppSettings["ApiUrlBase"]);
        public Uri ImgUrlBase = new Uri(ConfigurationManager.AppSettings["ImgUrlBase"]);
    }
}