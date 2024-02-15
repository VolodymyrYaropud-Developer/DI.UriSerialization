namespace Validation
{
    /// <summary>
    /// Presents the validator functionality.
    /// </summary>
    /// <typeparam name="T">The type parameter of object for validation.</typeparam>
    public interface IValidator<in T>
    {
        /// <summary>
        /// Verify the source object.
        /// </summary>
        /// <param name="obj">Type of T object.</param>
        /// <returns>true if the source object is valid; otherwise, false.</returns>
        bool IsValid(T obj);
    }
}
