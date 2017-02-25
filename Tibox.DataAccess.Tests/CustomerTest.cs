﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tibox.UnitOfWork;
using System.Linq;
using Tibox.Models;

namespace Tibox.DataAccess.Tests
{
    [TestClass]
    public class CustomerTest
    {
        private readonly TiboxUnitOfWork _unit;
        public CustomerTest()
        {
            _unit = new TiboxUnitOfWork();
        }

        [TestMethod]
        public void Get_All_Customer()
        {
            var customerList = _unit.Customers.GetAll();
            Assert.AreEqual(customerList.Count() > 0, true);
        }

        [TestMethod]
        public void Insert_Customer()
        {
            var customer = new Customer
            {
                FirstName="Julio",
                LastName="Velarde",
                City="Huancavelica",
                Country="Peru",
                Phone="555-555-555"
            };
            Assert.AreEqual(_unit.Customers.Insert(customer)>0, true);
        }

        [TestMethod]
        public void Delete_Customer()
        {
            var customer = _unit.Customers.SearchByNames("Julio", "Velarde");
            Assert.AreEqual(customer!=null, true);

            Assert.AreEqual(_unit.Customers.Delete(customer), true);
        }
    }
}
