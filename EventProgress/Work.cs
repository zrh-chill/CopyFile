using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventProgress
{
    public class Work
    {
        public event EventHandler<ValueChangedArg> ValueChanged;

        /// <summary>
        /// 触发事件
        /// </summary>
        /// <param name="currentDwg"></param>
        /// <param name="totlDwg"></param>
        public void SetValue(int currentDwg)
        {
            ValueChangedArg valueChangedArg = new ValueChangedArg
            {
                CurrentDwg = currentDwg,
            };

            while (ValueChanged == null) ;

            ValueChanged.Invoke(this, valueChangedArg);
        }
    }
}
