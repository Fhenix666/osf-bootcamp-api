using System;
using BootCamp.Adm.ViewModels.Output;

namespace BootCamp.Adm.ViewModels
{

    public class OutputUserViewModel : BinnacleViewModel
    {

        public string Name { get; set; }

        public string FirstLastName { get; set; }

        public string SecondLastName { get; set; }

        public string BusinessEmail { get; set; }

        public string PersonalEmail { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

        public int UserStatusFK { get; set; }

        public int ProfileFK { get; set; }

        public Nullable<int> OfficeFK { get; set; }
    }
}
