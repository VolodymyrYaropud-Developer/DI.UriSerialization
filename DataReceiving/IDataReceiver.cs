using System.Collections.Generic;

namespace DataReceiving
{
    /// <summary>
    /// Presents the string receiver functionality.
    /// </summary>
    public interface IDataReceiver
    {
        /// <summary>
        /// Receives the sequence of string that represent information about data that can be hierarchically represented.
        /// </summary>
        /// <returns>Sequence of string that represent information about data that can be hierarchically represented.</returns>
        IEnumerable<string> Receive();
    }
}
