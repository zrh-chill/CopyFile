using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForWPF.viewmodel.Impl
{
    internal class CommandTestAttributeImpl
    {
        public CommandTestViewModel ViewModel { get; private set; }

        public CommandTestAttributeImpl(CommandTestViewModel viewModel) 
        {
            ViewModel = viewModel;
        }

        private bool _canExecute = true;
        public bool CanExecute
        {
            get { return _canExecute; }
            set
            {
                _canExecute = value;
                ViewModel.RaisePropertyChanged();
            }
        }
    }
}
