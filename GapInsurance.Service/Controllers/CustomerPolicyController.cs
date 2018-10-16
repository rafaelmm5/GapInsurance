using GapInsurance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GapInsurance.Service.Controllers
{
    [RoutePrefix("api/CustomerPolicy")]
    public class CustomerPolicyController : ApiController
    {
        private readonly IPolicyManager policyManager;

        public CustomerPolicyController(IPolicyManager policyManager)
        {
            this.policyManager = policyManager;
        }

        [Authorize]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(policyManager.GetCustomerPolices());
        }

        [Authorize]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var policy = policyManager.GetCustomerPolicy(id);

            if (policy != null)
                return Ok(policy);

            return NotFound();
        }

        [Authorize]
        [Route("")]
        public IHttpActionResult Post([FromBody]Customer_PoliciesDto policy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var updatedPolicy = policyManager.SaveCustomerPolicy(policy);

                return Ok(updatedPolicy);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

    }
}
