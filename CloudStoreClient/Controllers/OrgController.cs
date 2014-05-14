using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CloudStoreClient.Helper;
using ServMan.ApiV1.Models;

namespace CloudStoreClient.Controllers
{
    public class OrgController : ApiController
    {
        private readonly Guid _rootId = new Guid("00000000-0000-0000-0000-000000000001");
        private readonly string _rootSecret = "00000000-0000-0000-0000-000000000001";
        private readonly Guid _rootOrgId = new Guid("00000000-0000-0000-0000-000000000001");
        private readonly Uri baseUri = new Uri("http://localhost/CloudFactoryStore/api/v1/");

        private readonly Uri orgBaseUri;

        public OrgController()
        {
            orgBaseUri = new Uri(baseUri, "Organization/");
        }


        [HttpGet]
        public IEnumerable<OrganizationListItem> Get()
        {
            var client = new HttpClientHelper(_rootId, _rootSecret);
            var orgList = client.DoGet<IEnumerable<OrganizationListItem>>(orgBaseUri);
            return orgList;
        }

        [HttpGet]
        public Organization Get(string id)
        {
            var client = new HttpClientHelper(_rootId, _rootSecret);
            var orgList = client.DoGet<Organization>(new Uri(orgBaseUri, id));
            return orgList;
        }

        [HttpPost]
        public void Post([FromBody]Organization org)
        {
            var client = new HttpClientHelper(_rootId, _rootSecret);
            client.DoPost<Organization>(orgBaseUri, org);
        }
    }
}
