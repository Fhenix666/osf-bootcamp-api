namespace BootCamp.Adm.ViewModels
{
    /// <summary>
    /// UserRequestViewModel
    /// </summary>
    public class InputUserViewModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string FirstLastName { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string SecondLastName { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string BusinessEmail { get; set; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string PersonalEmail { get; set; }
        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        /// <value>
        /// The phone.
        /// </value>
        public string Phone { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }
        /// <summary>
        /// Gets or sets the UserStatusFK type identifier.
        /// </summary>
        /// <value>
        /// The status type identifier.
        /// </value>
        public int UserStatusFK { get; set; }
        /// <summary>
        /// Gets or sets the profile fk.
        /// </summary>
        /// <value>
        /// The profile fk.
        /// </value>
        public int ProfileFK { get; set; }
        /// <summary>
        /// Gets or sets the office fk.
        /// </summary>
        /// <value>
        /// The office fk.
        /// </value>
        public int OfficeFK { get; set; }
    }
}
