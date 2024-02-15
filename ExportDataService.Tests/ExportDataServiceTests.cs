using System;
using System.IO;
using System.Xml.Linq;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Org.XmlUnit.Builder;
using Org.XmlUnit.Diff;

namespace ExportDataService.Tests
{
    public class ExportDataServiceTests
    {
        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForXmlSerializers))]
        public void RunForXmlSerializationTest(IServiceProvider serviceProvider, string sourcePath,
            string resultPath)
        {
            var service = serviceProvider.GetService<ExportDataService<Uri>>();
            service?.Run();
            var actual = XDocument.Load(sourcePath);
            var expected = XDocument.Load(resultPath);
            Diff diff = DiffBuilder.Compare(expected).WithTest(actual)
                .CheckForSimilar()
                .Build();
            Assert.IsFalse(diff.HasDifferences(), diff.ToString());
        }

        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForJsonSerializers))]
        public void RunForJsonSerializationTest(IServiceProvider serviceProvider, string sourcePath,
            string resultPath)
        {
            var service = serviceProvider.GetService<ExportDataService<Uri>>();
            service?.Run();
            using var readerActual = new StreamReader(sourcePath);
            var actual = readerActual.ReadToEnd();
            using var readerExpected = new StreamReader(resultPath);
            var expected = readerExpected.ReadToEnd();
            StringAssert.AreEqualIgnoringCase(expected, actual);
        }
    }
}
