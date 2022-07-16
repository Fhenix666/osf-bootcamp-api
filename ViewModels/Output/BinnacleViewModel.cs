using System;

namespace BootCamp.Adm.ViewModels
{

    public class BinnacleViewModel : BaseViewModel
    {
        public Nullable<int> CreatedBy { get; set; }

        public Nullable<int> UpdatedBy { get; set; }

        public OutputUserViewModel User { get; set; }
    }
}
