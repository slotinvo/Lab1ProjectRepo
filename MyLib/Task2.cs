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

        public void ItHappens(int timeSleep)
        {
            Thread.Sleep(timeSleep);
            Console.WriteLine("Отправка рассылки от Countdown!");
            handler?.Invoke(this, "Привет!");
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
            Console.WriteLine($"Подписчик {name} реагирует на событие Countdown. Сообщение: {e}");
        }
    }
}
