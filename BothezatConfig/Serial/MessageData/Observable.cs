using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BothezatConfig.Serial.MessageData
{
    public class Observable
    {

        public delegate void Observer(Observable source);

        private event Observer observer;

        public void AddObserver(Observer observer)
        {
            this.observer += observer;
        }

        public void RemoveObserver(Observer observer)
        {
            this.observer -= observer;
        }

        public void Notify()
        {
            if (observer != null)
                observer(this);
        }

    }
}
