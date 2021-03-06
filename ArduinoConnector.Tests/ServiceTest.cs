// <copyright file="ServiceTest.cs">Copyright ©  2018</copyright>
using System;
using ArduinoConnector;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;

namespace ArduinoConnector.Tests
{
    /// <summary>Cette classe contient des tests unitaires paramétrables pour Service</summary>
    [PexClass(typeof(Service))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestFixture]
    public partial class ServiceTest
    {
        /// <summary>Stub de test pour ProcessData(String)</summary>
        [PexMethod]
        public void ProcessDataTest(string data)
        {
            Service.ProcessData(data);
            // TODO: ajouter des assertions à méthode ServiceTest.ProcessDataTest(String)
        }
    }
}
