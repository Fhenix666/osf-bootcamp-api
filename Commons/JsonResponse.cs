namespace BootCamp.Adm.Commons
{
    /// <summary>
    /// JsonResponse
    /// </summary>
    public class JsonResponse
    {
        /// <summary>
        /// Gets or sets the success.
        /// </summary>
        /// <value>
        /// The success.
        /// </value>
        public int Success { get; set; } = 1;

        /// <summary>
        /// Gets or sets the failure.
        /// </summary>
        /// <value>
        /// The failure.
        /// </value>
        public int Failure { get; set; } = 0;
        /// <summary>
        /// Gets or sets the o data.
        /// </summary>
        /// <value>
        /// The o data.
        /// </value>
        public object oData { get; set; }
    }
}
