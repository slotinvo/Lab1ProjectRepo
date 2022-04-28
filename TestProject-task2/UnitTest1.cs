using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLib;
using System;
using System.Linq;

namespace TestProject_task2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Countdown[] countdowns = {
                new Countdown("Охота и рыбалка"),
                new Countdown("Карусель"),
                new Countdown("Новости 24")
            };
            Subscriber[] subscribers = {
                new Subscriber("Виктор Слотин", new string[]{ "Охота и рыбалка", "Новости 24" }),
                new Subscriber("Анастасия Петрова", new string[]{ "Охота и рыбалка", "Карусель" }),
                new Subscriber("Александр Калиничев", new string[]{ "Карусель", "Новости 24" })
            };

            Countdown ChannelWithNewContent = countdowns[1];

            foreach (Subscriber subs in subscribers)
            {
                subs.NewNotification(ChannelWithNewContent);
            }
            string mess = "На канале " + ChannelWithNewContent.channelName + " вышло новое видео!";
            ChannelWithNewContent.Mailing(1000, mess);
            foreach (Subscriber subs in subscribers)
            {
                string rigthEcho = "";
                if (subs.subscriptions.Contains(ChannelWithNewContent.channelName)) 
                {
                    rigthEcho = subs.name + "!" + mess;
                } 
                Assert.AreEqual(subs.echo, rigthEcho);
            }
        }
    }
}