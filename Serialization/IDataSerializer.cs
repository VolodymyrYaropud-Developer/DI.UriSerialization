using System;
using System.Collections.Generic;

namespace Serialization
{
    /// <summary>
    /// Presents data serializer functionality.
    /// </summary>
    /// <typeparam name="T">Type of the serializable sequence.</typeparam>
    public interface IDataSerializer<in T>
    {
        /// <summary>
        /// Serializes the sequence of type T elements.
        /// </summary>
        /// <param name="source">Sequence of type T elements.</param>
        /// <exception cref="ArgumentNullException">Throw if source is null.</exception>
        void Serialize(IEnumerable<T>? source);
    }
}
