using DbCrud.Data;
using DbCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCrud.Controllers
{
    public class CustomerController : Controller
    {
        private readonly exampleAspDotNetContext _context;

        public CustomerController(exampleAspDotNetContext context)
        {
            _context = context;
        }
        public IActionResult Index(int pg = 1)
        {
            const int pageSize = 10;

            if (pg < 1)
                pg = 1;

            int recsCount = _context.Customers.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            List<Customer> customers = _context.Customers.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;


            return View(customers);
            
        }

        public IActionResult Detalis(string Id)
        {
            Customer customer = _context.Customers.Where(p => p.CustomerId == Id).FirstOrDefault();
            return View(customer);
        }

        [HttpGet]
        public IActionResult Edit(string Id)
        {
            Customer customer = _context.Customers.Where(p => p.CustomerId == Id).FirstOrDefault();
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            _context.Attach(customer);
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(string Id)
        {
            Customer customer = _context.Customers.Where(p => p.CustomerId == Id).FirstOrDefault();
            return View(customer);
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            _context.Attach(customer);
            _context.Entry(customer).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            var customerid = _context.Customers.Max(cusid => cusid.CustomerId);
            long customerNo;

            Int64.TryParse(customerid.Substring(2, customerid.Length - 2), out customerNo);
            if (customerNo > 0)
            {
                customerNo = customerNo + 1;
                customerid = "CS" + customerNo.ToString();
            }
            customer.CustomerId = customerid;
            _context.Attach(customer);
            _context.Entry(customer).State = EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
