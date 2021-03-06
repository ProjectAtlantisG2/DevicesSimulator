// <copyright file="ServiceTest.cs">Copyright ©  2018</copyright>
using System;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Web;
using GatewayService;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Moq;
using NUnit.Framework;

namespace GatewayService.Tests
{
    /// <summary>Cette classe contient des tests unitaires paramétrables pour Service</summary>
    [PexClass(typeof(Service))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestFixture]
    public partial class ServiceTest
    {
        /// <summary>Stub de test pour PostCommand(String)</summary>
        [PexMethod]
        public HttpResponseMessage PostCommandTest(string command)
        {
            Mock<Service> mock = new Mock<Service>();
            return mock.Object.PostCommand(command, "11:11:11:11:11");
        }

        [Test]
        public void PostCommandEmpty()
        {
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, this.PostCommandTest("").StatusCode);
        }

        [Test]
        public void PostCommandNull()
        {
            Assert.AreEqual(HttpStatusCode.MethodNotAllowed, this.PostCommandTest(null).StatusCode);
        }

        [Test]
        public void PostCommandWorking()
        {
            Assert.IsTrue(HttpStatusCode.OK == this.PostCommandTest("Hello").StatusCode ||
                HttpStatusCode.InternalServerError == this.PostCommandTest("Hello").StatusCode, "Failed");
        }
    }
}
