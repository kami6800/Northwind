using System;
using Xunit;
using NorthwindEntities.Models;
using System.Linq;
using System.Collections.Generic;
using WebApi.Controllers;
using DataAccess;


namespace OrderTests
{
    public class OrdersTesting
    {
        NorthwindContext context = new NorthwindContext();
        OrdersController controller = new OrdersController();

        [Fact]
        public void GetIncompleteOrdersTest()
        {
            string customer = "anton";

            List<Orders> expected = context.Orders
                .Where(o => o.ShippedDate == null)
                .Where(o => o.CustomerId == customer)
                .ToList();
            List<Orders> actual = controller.GetIncompleteOrdersByCustomer(customer);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetIncompleteOrdersByCustomerTest()
        {
            List<Orders> expected = context.Orders.Where(o => o.ShippedDate == null).ToList();
            List<Orders> actual = controller.GetIncompleteOrders();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetAllInvoicesTest()
        {
            List<Invoices> expected = context.Invoices.ToList();
            List<Invoices> actual = controller.Get();

            Assert.True(expected.SequenceEqual(actual));
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetAllInvoicesByCustomerTest()
        {
            string customer = "anton";

            List<Invoices> expected = context.Invoices.Where(o => o.CustomerId == customer).ToList();
            List<Invoices> actual = controller.Get(customer);

            Assert.Equal(expected, actual);
            Assert.Equal(expected[0].GetHashCode(), actual[0].GetHashCode());
        }
    }
}
