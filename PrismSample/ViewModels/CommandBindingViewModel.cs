using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PrismSample.ViewModels
{
    internal class CommandBindingViewModel : BindableBase
    {
		private bool _canExcute = true;

		public bool CanExcute
		{
			get
			{
				return _canExcute;
			}
			set
			{
				SetProperty(ref _canExcute, value);
            }
		}

		private string _currentTime;

		public string CurrentTime
		{
			get { return _currentTime; }
			set { SetProperty(ref _currentTime, value); }
		}

        public DelegateCommand GetCurrentTimeCommand => new DelegateCommand(() =>
		{
			this.CurrentTime = DateTime.Now.ToString();
		}).ObservesCanExecute(() => CanExcute);

		public DelegateCommand<object> GetCurrentTimeParamCommand => new DelegateCommand<object>((object o) =>
		{
            this.CurrentTime = ((Button)o)?.Name + DateTime.Now.ToString();
        }).ObservesCanExecute(() => CanExcute);

		private string _foo;

		public string Foo
		{
			get { return _foo; }
			set { SetProperty(ref _foo, value); }
		}

		public DelegateCommand<object> TextChangedCommand => new DelegateCommand<object>((o) =>
		{
            this.CurrentTime = Foo + ((Button)o)?.Name;
        });

		public DelegateCommand<TextChangedEventArgs> TextChangedCommandArg => new DelegateCommand<TextChangedEventArgs>((o) =>
		{
			this.CurrentTime = Foo + o.Changes.FirstOrDefault()?.Offset;
		});

		public DelegateCommand AsyncCommand => new DelegateCommand(async () =>
		{
			await Task.Run(() =>
			{ 
				for(int i = 0; i < 5; i++)
				{
                    this.CurrentTime = DateTime.Now.ToString();
					Thread.Sleep(1000);
                }
			});
		});

	}
}
