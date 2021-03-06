// <copyright file="UtilsTest.cs">Copyright ©  2018</copyright>

using System;
using System.Text.RegularExpressions;
using ArduinoConnector;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Moq;
using NUnit.Framework;

namespace ArduinoConnector.Tests
{
    /// <summary>Cette classe contient des tests unitaires paramétrables pour Utils</summary>
    [TestFixture]
    [PexClass(typeof(Utils))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class UtilsTest
    {

        /// <summary>Stub de test pour GenerateMACAddress()</summary>
        [PexMethod]
        internal string GenerateMACAddressTest()
        {
            Mock<Utils> mock = new Mock<Utils>();
            return mock.Object.GenerateMACAddress();
            // TODO: ajouter des assertions à méthode UtilsTest.GenerateMACAddressTest(Utils)
        }

        [Test]
        public void AssertMacAddressFormat()
        {
            string result = this.GenerateMACAddressTest();
            
            Assert.IsTrue(Regex.Match(result,
                "[A-Za-z0-9][A-Za-z0-9]:[A-Za-z0-9][A-Za-z0-9]:[A-Za-z0-9][A-Za-z0-9]:[A-Za-z0-9][A-Za-z0-9]:[A-Za-z0-9][A-Za-z0-9]")
                .Success
                );
        }
    }
}
