using System;
using JXDevPlanner.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JXDevPlanner.Tests
{
    [TestClass]
    public class PlanItemService_Test
    {
        PlanItemService svc = new PlanItemService(new Guid());

        [TestMethod]
        public void PlanItemService_GetPlanItemById_Test()
        {
            var id = Guid.Parse("c9610ba5-3bbe-4c1e-9c9d-730751f7619a");

            var item = svc.GetPlanItemById(id);

            Assert.AreEqual(id,item.PlanItemID);
        }
    }
}
