﻿using GapInsurance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GapInsurance.Service.Controllers
{
    [RoutePrefix("api/Client")]
    public class ClientController : ApiController
    {
        private readonly IClientManager clientManager;

        public ClientController(IClientManager clientManager)
        {
            this.clientManager = clientManager;
        }

        [Authorize]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(clientManager.GetClients());
        }

        [Authorize]
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            var client = clientManager.GetClient(id);

            if (client == null)
                return NotFound();

            return Ok(client);
        }

        [Authorize]
        [Route("")]
        public IHttpActionResult Post([FromBody]ClientsDto client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedClient = clientManager.SaveClient(client);

            return Ok(updatedClient);
        }
    }
}
