using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class Countdown
    {
        public event EventHandler<string[]>? handler;
        public string channelName;
        public Countdown(string channelName)
        {
            this.channelName = channelName;
        }

        public void Mailing(int timeSleep, string messege)
        {
            string[] args = new string[2];
            args[0] = channelName;
            args[1] = messege;
            Thread.Sleep(timeSleep);
            Console.WriteLine("Отправка рассылки от канала " + channelName);
            handler?.Invoke(this, args);
        }
    }
    public class Subscriber
    {
        public readonly string name;
        public readonly string[] subscriptions;
        public string echo;
        public Subscriber(string name, string[] subscriptions)
        {
            this.name = name;
            this.subscriptions = subscriptions;
            this.echo = "";
        }
        public void NewNotification(Countdown cd)
        {
            cd.handler += DisplayMessage;
        }
        private void DisplayMessage(object? sender, string[] args)
        {
            if (subscriptions.Contains(args[0]))
            {
                this.echo = name + "!" + args[1];
                Console.WriteLine(echo);
            }
        }
    }
}
