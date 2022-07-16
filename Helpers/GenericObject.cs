using System.Reflection;

namespace BootCamp.Adm.Helpers
{
    /// <summary>
    /// GenericObject
    /// </summary>
    public static class GenericObject
    {
        private const bool True = true;
        private const bool False = false;

        /// <summary>
        /// Tries the set property.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="property">The property.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool TrySetProperty(object obj, string property, object value)
        {
            var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
            {
                prop.SetValue(obj, value, null);
                return True;
            }
            return False;
        }
    }
}
