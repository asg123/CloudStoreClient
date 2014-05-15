using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudStoreClient.Helper
{
    public class Config
    {
        public Guid UserId = new Guid("00000000-0000-0000-0000-000000000001");
        public string Secret = "00000000-0000-0000-0000-000000000001";
        public Guid OrganizationId = new Guid("00000000-0000-0000-0000-000000000002");
        public Uri ApiUrlBase = new Uri("http://localhost/CloudFactoryStore/api/v1/");
        public Uri ImgUrlBase = new Uri("http://localhost/CloudFactoryStore/");
    }
}