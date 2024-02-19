using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForWPF.Model
{
    internal class DgModel : BindableBase
    {
        public DgModel()
        {
            Tasks = new ObservableCollection<TaskBase>
            {
                new ATask(), new BTask()
            };
        }

        public string Name { get; set; } = Guid.NewGuid().ToString();

        private ObservableCollection<TaskBase> _tasks;

        public ObservableCollection<TaskBase> Tasks
        {
            get { return _tasks; }
            set { SetProperty(ref _tasks, value); }
        }
    }

    internal abstract class TaskBase
    {
        public abstract string Header { get; set; }

        public abstract string Content { get; set; }
    }

    internal class ATask : TaskBase
    {
        public override string Header { get; set; } = "Header A";

        public override string Content { get; set; } = "Content A";
    }

    internal class BTask : TaskBase
    {
        public override string Header { get; set; } = "Header B";

        public override string Content { get; set; } = "Content B";
    }
}
