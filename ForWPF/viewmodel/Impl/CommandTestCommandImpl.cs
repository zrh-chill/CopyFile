using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ForWPF.viewmodel.Impl
{
    internal class CommandTestCommandImpl
    {
        public CommandTestViewModel ViewModel { get; private set; }

        public CommandTestCommandImpl(CommandTestViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public RelayCommand NormalCommand => new RelayCommand(() =>
        {
            MessageBox.Show("普通命令");
        });

        public RelayCommand CanExecuteCommand => new RelayCommand(() =>
        {
            MessageBox.Show("可禁止命令");
        }, () =>
        {
            return ViewModel.AttributeImpl.CanExecute;
        });

        public RelayCommand<object> ParamCommand => new RelayCommand<object>((object o) =>
        {
            MessageBox.Show($"带参命令, 参数是：{o}");
        });
    }
}
