using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmTimer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MvvmTimer.ViewModel
{
    public class TestViewModel : ViewModelBase
    {
        public TestViewModel()
        {
            _timer.Interval = 2000; // 2000毫秒
            _timer.Elapsed += _timer_Elapsed;
        }

        private int _count = 0;

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if(_count == 3)
            {
                _count = 0;
                _timer.Stop();

                return;
            }

            System.Diagnostics.Debug.WriteLine($"{_count}");
            Models = new List<TestModel>() { new TestModel() { Data = _count } };

            _count++;
        }

        private Timer _timer = new Timer();

        private List<TestModel> _models;

        public List<TestModel> Models
        {
            get => _models;
            set
            {
                _models = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand StartCommand => new RelayCommand(() =>
        {
            _count = 0;
            _timer.Start();
        });

        public RelayCommand EndCommand => new RelayCommand(() =>
        {
            _count = 0;
            _timer.Stop();
        });
    }
}
