using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Truck.Application.Interfaces;
using Truck.Application.Services;
using Truck.CrossCuting.Enum;
using Truck.Data.Context;
using Truck.Data.Repository;
using Truck.Domain.Interfaces;
using Truck.Web.UI.Controllers;

namespace TruckTests
{
    [TestClass]
    public class UnitTest
    {

        [TestMethod]
        public async Task CreateTruck_TestYear2022()
        {
            Truck.Domain.Models.Truck obj= new Truck.Domain.Models.Truck();
            obj.IdModel = 1;
            obj.YearFabrication = 2022;
            obj.YearModel = 2022;
            obj.Description = "Test year 2022";

            var mock = new Mock<ITruckRepository>();
            mock.Setup(p => p.Create(It.IsAny<Truck.Domain.Models.Truck>()));

            TruckService serv = new TruckService(mock.Object);
            var result = await serv.Create(obj);

            Assert.AreEqual(Return.added, result.status, "Error in insert Truck with year 2022");
        }

        [TestMethod]
        public async Task CreateTruck_TestYear2021()
        {
            Truck.Domain.Models.Truck obj = new Truck.Domain.Models.Truck();
            obj.IdModel = 1;
            obj.YearFabrication = 2021;
            obj.YearModel = 2021;
            obj.Description = "Test year 2021";

            var mock = new Mock<ITruckRepository>();
            mock.Setup(p => p.Create(It.IsAny<Truck.Domain.Models.Truck>()));

            TruckService serv = new TruckService(mock.Object);
            var result = await serv.Create(obj);
            Assert.AreEqual(Return.error, result.status, "Error in insert Truck with year 2021");
        }

        [TestMethod]
        public async Task CreateTruck_TestModel_FH()
        {
            Truck.Domain.Models.Truck obj = new Truck.Domain.Models.Truck();
            obj.IdModel = 1; //FH
            obj.YearFabrication = 2022;
            obj.YearModel = 2022;
            obj.Description = "Test model FH";

            var mock = new Mock<ITruckRepository>();
            mock.Setup(p => p.Create(It.IsAny<Truck.Domain.Models.Truck>()));

            TruckService serv = new TruckService(mock.Object);
            var result = await serv.Create(obj);
            Assert.AreEqual(Return.added, result.status, "Error in insert Truck with model FH");
        }

        [TestMethod]
        public async Task CreateTruck_TestModel_Other()
        {
            Truck.Domain.Models.Truck obj = new Truck.Domain.Models.Truck();
            obj.IdModel = 3; //Other
            obj.YearFabrication = 2022;
            obj.YearModel = 2022;
            obj.Description = "Test model Other";

            var mock = new Mock<ITruckRepository>();
            mock.Setup(p => p.Create(It.IsAny<Truck.Domain.Models.Truck>()));

            TruckService serv = new TruckService(mock.Object);
            var result = await serv.Create(obj);
            Assert.AreEqual(Return.error, result.status, "Error in insert Truck with model Other");
        }

        [TestMethod]
        public async Task GetTruck_id1()
        {
            Truck.Domain.Models.Truck obj = new Truck.Domain.Models.Truck();
            obj.IdTruck = 1;
            obj.IdModel = 1;
            obj.YearFabrication = 2022;
            obj.YearModel = 2022;
            obj.Description = "Test year 2022";

            var mock = new Mock<ITruckRepository>();
            mock.Setup(p => p.Get(It.IsAny<int>())).Returns(Task.FromResult(obj));

            TruckService serv = new TruckService(mock.Object);
            var _obj = await serv.Get(obj.IdTruck);
            var result = _obj?.IdTruck ?? 0;

            Assert.AreEqual(result, obj.IdTruck, "Error in get Truck with id=1");
        }
        

        [TestMethod]
        public async Task EditTruck_id1_TestYearModel2021()
        {
            Truck.Domain.Models.Truck obj = new Truck.Domain.Models.Truck();
            obj.IdTruck = 1;
            obj.IdModel = 1;
            obj.YearFabrication = 2022;
            obj.YearModel = 2021;
            obj.Description = "Test edit year Model 2021";

            var mock = new Mock<ITruckRepository>();
            mock.Setup(p => p.Update(It.IsAny<Truck.Domain.Models.Truck>())).Returns(Task.FromResult(obj));

            TruckService serv = new TruckService(mock.Object);
            var result = await serv.Update(obj);

            Assert.AreEqual(Return.error, result.status, "Error in edit Truck with year Model 2021 and id=1");
        }

        [TestMethod]
        public async Task EditTruck_id1_TestModel2021()
        {
            Truck.Domain.Models.Truck obj = new Truck.Domain.Models.Truck();
            obj.IdTruck = 1;
            obj.IdModel = 3; //Other
            obj.YearFabrication = 2022;
            obj.YearModel = 2022;
            obj.Description = "Test edit Model Other";

            var mock = new Mock<ITruckRepository>();
            mock.Setup(p => p.Update(It.IsAny<Truck.Domain.Models.Truck>())).Returns(Task.FromResult(obj));

            TruckService serv = new TruckService(mock.Object);
            var result = await serv.Update(obj);

            Assert.AreEqual(Return.error, result.status, "Error in edit Truck with Model Other and id=1");
        }

    }
}