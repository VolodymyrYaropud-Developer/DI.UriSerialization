using System.Collections.Generic;
using DataReceiving;

namespace InMemoryReceiver
{
    /// <summary>
    /// In memory text class receiver. Use for testing.
    /// </summary>
    public class InMemoryDataReceiver : IDataReceiver
    {
        /// <summary>
        /// Receives lines from array of string.
        /// </summary>
        /// <returns>Strings.</returns>
        public IEnumerable<string> Receive() => new[]
        {
            "https://habrahabr.ru/company/it-grad/blog/341486/",
            "http://www.example.com/customers/12345",
            "http://www.example.com/customers/12345/orders/98765",
            "https://qaevolution.ru/znakomstvo-s-testirovaniem-api/",
            "http://",
            "https://www.contoso.com/Home/Index.htm?q1=v1&q2=v2",
            "http://aaa.com/temp?key=Foo&value=Bar&id=42",
            "https://www.w3schools.com/html/default.asp",
            "http://www.ninject.org/learn.html",
            "https:.php",
            "https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/concepts/linq/linq-to-xml-overview",
            "docs.microsoft.com",
            "microsoft.com/ru-ru/dotnet/csharp/programming-guide/concepts/l",
            "https://docs.microsoft.com/ru-ru/dotnet/api/system.linq.queryable.where?view=netframework-4.8",
            "https://docs.microsoft.com/en-us/dotnet/api/system.xml.serialization.xmlserializer?view=net-6.0",
            "https://metanit.com/python/django/1.1.php",
        };
    }
}
