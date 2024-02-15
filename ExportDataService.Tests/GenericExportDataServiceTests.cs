using System.Collections.Generic;
using System.Linq;
using Conversion;
using DataReceiving;
using Moq;
using NUnit.Framework;
using Serialization;
using Validation;

namespace ExportDataService.Tests
{
    public class GenericExportDataServiceTests
    {
        private Mock<IValidator<string>> validatorMock;
        private Mock<IDataReceiver> receiverMock;
        private Mock<IConverter<It.IsAnyType>> converterMock;
        private Mock<IDataSerializer<It.IsAnyType>> serializerMock;
        private const int count = 10;

        [SetUp]
        public void SetUp()
        {
            this.validatorMock = new Mock<IValidator<string>>();
            this.validatorMock.Setup(validator => validator.IsValid(It.IsAny<string>())).Returns(true);

            this.receiverMock = new Mock<IDataReceiver>();
            this.receiverMock.Setup(receiver => receiver.Receive()).Returns(Enumerable.Repeat(It.IsAny<string>(), count));

            this.converterMock = new Mock<IConverter<It.IsAnyType>>();
            this.converterMock.Setup(converter => converter.Convert(It.IsAny<string>()))
                .Callback<string?>(obj => this.validatorMock.Object.IsValid(obj))
                .Returns<string?>((obj) => new It.IsAnyType());

            this.serializerMock = new Mock<IDataSerializer<It.IsAnyType>>();
            this.serializerMock.Setup(serializer => serializer.Serialize(It.IsAny<IEnumerable<It.IsAnyType>?>()));
        }

        [Test]
        public void Receive_Method_Of_The_IDataReceiver_Interface_Call_One_Time()
        {
            var service =
                new ExportDataService<It.IsAnyType>(this.receiverMock.Object, this.serializerMock.Object, this.converterMock.Object);
            service.Run();
            this.receiverMock.Verify(receiver => receiver.Receive(), Times.Once);
            Assert.That(this.receiverMock.Object.Receive().Count() == count);
        }

        [Test]
        public void Serialize_Method_Of_The_IDataSerializer_Interface_Call_One_Time()
        {
            var service = new ExportDataService<It.IsAnyType>(this.receiverMock.Object, this.serializerMock.Object, this.converterMock.Object);
            service.Run();
            this.serializerMock.Verify(receiver => receiver.Serialize(It.IsAny<IEnumerable<It.IsAnyType>?>()), Times.Once);
        }

        [Test]
        public void Convert_And_IsValid_Methods_Of_The_IValidator_And_IConverter_Interfaces_Call_Exactly_Count_Times()
        {
            var service = new ExportDataService<It.IsAnyType>(this.receiverMock.Object, this.serializerMock.Object, this.converterMock.Object);
            service.Run();
            this.validatorMock.Verify(validator => validator.IsValid(It.IsAny<string>()), Times.Exactly(count));
            this.converterMock.Verify(converter => converter.Convert(It.IsAny<string>()), Times.Exactly(count));
        }
    }
}
