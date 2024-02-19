using ForWPF.Model;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForWPF.viewmodel
{
    internal class DataGridViewModel : BindableBase
    {
        private ObservableCollection<DgModel> _dgModels = new ObservableCollection<DgModel>() { new DgModel(), };

        public ObservableCollection<DgModel> DgModels
        {
            get { return _dgModels; }
            set { SetProperty(ref _dgModels, value); }
        }
    }
}
