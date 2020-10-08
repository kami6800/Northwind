using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess;
using NorthwindEntities.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [Route("incomplete")]
        [HttpGet]
        public List<Orders> GetIncompleteOrders()
        {
            return OrderRepository.GetIncompleteOrders();
        }

        [Route("incomplete/{id}")]
        [HttpGet("{id}")]
        public List<Orders> GetIncompleteOrdersByCustomer(string id)
        {
            return OrderRepository.GetIncompleteOrdersByCustomer(id);
        }

        // GET: api/Orders
        [HttpGet]
        public List<Invoices> Get()
        {
            return OrderRepository.GetAllInvoices();
        }

        // GET: api/Orders/5
        [HttpGet("{id}", Name = "Get")]
        public List<Invoices> Get(string id)
        {
            return OrderRepository.GetInvoicesByCustomer(id);
        }

        // POST: api/Orders
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
