using System;
using NUnit.Framework;
using UriConversion;

namespace ExportDataService.Tests
{
    internal class UriValidatorTests
    {
        [TestCaseSource(typeof(TestCasesData), nameof(TestCasesData.TestCasesForUriValidator))]
        public void IsValidTests(string source, bool expected)
        {
            var validator = new UriValidator();
            Assert.AreEqual(expected, validator.IsValid(source));
        }

        [Test]
        public void IsValid_Throw_ArgumentNullException_If_SourceString_Is_Null()
        {
            Assert.Throws<ArgumentNullException>(() => new UriValidator().IsValid(null));
        }
    }
}
