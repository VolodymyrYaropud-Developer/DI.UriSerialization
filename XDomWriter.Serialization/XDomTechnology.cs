using System;
using System.Collections.Generic;
using Serialization;
using Microsoft.Extensions.Logging;

namespace XDomWriter.Serialization
{
    /// <summary>
    /// Presents the serialization functionality of the sequence<see cref="IEnumerable{Uri}"/>
    /// with using X-DOM model.
    /// </summary>
    public class XDomTechnology : IDataSerializer<Uri>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XDomTechnology"/> class.
        /// </summary>
        /// <param name="path">The path to json file.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="ArgumentException">Throw if text reader is null or empty.</exception>
        public XDomTechnology(string? path, ILogger<XDomTechnology>? logger = default)
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
