using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ForWPF.viewmodel
{
    internal class EventTestViewModel : ViewModelBase
    {
        private bool _isReceiveMouseMove = true;

        public bool IsReceiveMouseMove 
        {
            get { return _isReceiveMouseMove; } 
            set {  _isReceiveMouseMove = value;
                RaisePropertyChanged();
            } 
        }

        private string _tipText = "";
        public string TipText 
        {
            get => _tipText;
            set { _tipText = value; RaisePropertyChanged(); }
        }

        public RelayCommand<MouseEventArgs> MouseMoveCommand => new RelayCommand<MouseEventArgs>((e) =>
        {
            var point = e.GetPosition(e.Device.Target);
            TipText = $"当前位置 -> X:{point.X} Y:{point.Y}; 鼠标状态：{e.LeftButton}、{e.MiddleButton}、{e.RightButton}";
        });
    }
}
