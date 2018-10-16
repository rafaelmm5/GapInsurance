using GapInsurance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GapInsurance.Service.Controllers
{
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        private readonly IClientManager clientManager;

        public CustomerController(IClientManager clientManager)
        {
            this.clientManager = clientManager;
        }

        [Authorize]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(clientManager.GetCustomers());
        }

        [Authorize]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var customer = clientManager.GetCustomer(id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [Authorize]
        [Route("")]
        public IHttpActionResult Post([FromBody]CustomersDto customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedCustomer = clientManager.SaveCustomer(customer);

            return Ok(updatedCustomer);
        }

    }
}
