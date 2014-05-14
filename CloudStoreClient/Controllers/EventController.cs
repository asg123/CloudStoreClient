using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServMan.Messages.Events;

namespace CloudStoreClient.Controllers
{
    public class EventController : ApiController
    {
        [HttpPost]
        public void UserUpdated([FromBody]UserUpdated user)
        {
            var u = user;
        }
        [HttpPost]
        public void UserCreated([FromBody]UserCreated user)
        {
            var u = user;
        }
        [HttpPost]
        public void OrganizationCreated([FromBody]OrganizationCreated org)
        {
            var o = org;
        }
        [HttpPost]
        public void OrganizationUpdated([FromBody]OrganizationUpdated org)
        {
            var o = org;
        }
    }
}
