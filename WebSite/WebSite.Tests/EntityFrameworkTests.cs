using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSite.Data.EntityFramework.DataServices;
using WebSite.Data.Business.Entities;
using WebSite.Data.Business.Services;
using WebSite.Data.EntityFramework;

namespace WebSite.Tests
{
    [TestClass]
    public class EntityFrameworkTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Product p = new Product() { ProductName = "Drugi produktsdf", ProductDescription = "Opis tego drugiego produktusdf", PricePerUnit = 12.45M, QuantityPerUnit = 4.56F };
            TransactionalInformation tr = new TransactionalInformation();
            ProductDataService pr = new ProductDataService();
            ProductBusinessService prs = new ProductBusinessService(pr);
            prs.CreateProduct(p, out tr);
            Assert.IsTrue(tr.ReturnStatus);
        }
    }
}
