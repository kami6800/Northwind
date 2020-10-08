using System;
using System.Collections.Generic;
using System.Linq;
using NorthwindEntities.Models;

namespace DataAccess
{
    public class OrderRepository
    {
        static NorthwindContext context = new NorthwindContext();

        static public List<Invoices> GetAllInvoices()
        {
            return context.Invoices.ToList();
        }


        static public List<Invoices> GetInvoicesByCustomer(string customerId)
        {
            return context.Invoices.Where(o => o.CustomerId == customerId).ToList();
        }

        static public List<Orders> GetIncompleteOrders()
        {
            return context.Orders.Where(o => o.ShippedDate == null).ToList();
        }

        static public List<Orders> GetIncompleteOrdersByCustomer(string customerId)
        {
            return context.Orders.Where(o => o.ShippedDate == null).Where(o => o.CustomerId == customerId).ToList();
        }
    }
}
