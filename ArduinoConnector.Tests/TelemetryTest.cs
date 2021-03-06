// <copyright file="TelemetryTest.cs">Copyright ©  2018</copyright>

using System;
using ArduinoConnector;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;

namespace ArduinoConnector.Tests
{
    /// <summary>Cette classe contient des tests unitaires paramétrables pour Telemetry</summary>
    [TestFixture]
    [PexClass(typeof(Telemetry))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class TelemetryTest
    {

        /// <summary>Stub de test pour .ctor(Nullable`1&lt;DateTime&gt;, Nullable`1&lt;DeviceType&gt;, String)</summary>
        [PexMethod]
        public Telemetry ConstructorTest(
            string metricDate,
            DeviceType? deviceType,
            string metricValue
        )
        {
            Telemetry target = new Telemetry(metricDate, deviceType, metricValue);
            return target;
            // TODO: ajouter des assertions à méthode TelemetryTest.ConstructorTest(Nullable`1<DateTime>, Nullable`1<DeviceType>, String)
        }
    }
}
