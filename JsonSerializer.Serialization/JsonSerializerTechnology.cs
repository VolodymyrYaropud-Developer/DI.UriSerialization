using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Serialization;

namespace JsonSerializer.Serialization
{
    /// <summary>
    /// Presents the serialization functionality of the sequence<see cref="IEnumerable{Uri}"/>
    /// with using JsonSerialization class.
    /// </summary>
    public class JsonSerializerTechnology : IDataSerializer<Uri>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonSerializerTechnology"/> class.
        /// </summary>
        /// <param name="path">The path to json file.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="ArgumentException">Throw if text reader is null or empty.</exception>
        public JsonSerializerTechnology(string? path, ILogger<JsonSerializerTechnology>? logger = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serializes the source sequence of Uri elements in json format. 
        /// </summary>
        /// <param name="source">The source sequence of Uri elements.</param>
        /// <exception cref="ArgumentNullException">Throw if the source sequence is null.</exception>
        public void Serialize(IEnumerable<Uri>? source)
        {
            throw new NotImplementedException();
        }
    }
}
