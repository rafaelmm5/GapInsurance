using GapInsurance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GapInsurance.Service.Controllers
{
    [RoutePrefix("api/Policy")]
    public class PolicyController : ApiController
    {
        private readonly IPolicyManager policyManager;

        public PolicyController(IPolicyManager policyManager)
        {
            this.policyManager = policyManager;
        }

        [Authorize]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(policyManager.GetPolicies());
        }

        [Authorize]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var policy = policyManager.GetPolicy(id);

            if (policy != null)
                return Ok(policy);

            return NotFound();
        }

        [Authorize]
        [Route("")]
        public IHttpActionResult Post([FromBody]PoliciesDto policy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedPolicy = policyManager.SavePolicy(policy);

            return Ok(updatedPolicy);
        }
       

    }

}
