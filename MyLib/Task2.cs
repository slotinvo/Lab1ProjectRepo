using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class Countdown
    {
        public event EventHandler<string>? handler;

        public void ItHappens(int delay)
        {
            Thread.Sleep(delay);
            Console.WriteLine("Countdown send a message!");
            handler?.Invoke(this, "nothing really happens...");
        }
    }
    public class Subscriber
    {
        private readonly string name;
        public Subscriber(Countdown cd, string name)
        {
            cd.handler += DisplayMessage;
            this.name = name;
        }

        private void DisplayMessage(object? sender, string e)
        {
            Console.WriteLine($"Subscriber {name} reacts to event. Publisher says: {e}");
        }
    }
}
