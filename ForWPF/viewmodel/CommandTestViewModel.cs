using ForWPF.viewmodel.Impl;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ForWPF.viewmodel
{
    internal class CommandTestViewModel : ViewModelBase
    {
        public CommandTestAttributeImpl AttributeImpl { get; private set; }
        public CommandTestCommandImpl CommandImpl { get; private set; }

        public CommandTestViewModel() 
        {
            AttributeImpl = new CommandTestAttributeImpl(this);
            CommandImpl = new CommandTestCommandImpl(this);
        }   
    }
}
