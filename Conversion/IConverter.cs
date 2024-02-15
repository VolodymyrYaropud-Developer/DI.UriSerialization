namespace Conversion
{
    /// <summary>
    /// Presents the converter functionality.
    /// </summary>
    /// <typeparam name="T">Type of the result object.</typeparam>
    public interface IConverter<out T>
    {
        /// <summary>
        /// Convert the string object representation to T type.
        /// </summary>
        /// <param name="obj">The source string object representation.</param>
        /// <returns>The converted object.</returns>
        T? Convert(string? obj);
    }
}
