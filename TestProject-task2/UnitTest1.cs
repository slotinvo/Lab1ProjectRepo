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
                new Countdown("����� � �������"),
                new Countdown("��������"),
                new Countdown("������� 24")
            };
            Subscriber[] subscribers = {
                new Subscriber("������ ������", new string[]{ "����� � �������", "������� 24" }),
                new Subscriber("��������� �������", new string[]{ "����� � �������", "��������" }),
                new Subscriber("��������� ���������", new string[]{ "��������", "������� 24" })
            };

            Countdown ChannelWithNewContent = countdowns[1];

            foreach (Subscriber subs in subscribers)
            {
                subs.NewNotification(ChannelWithNewContent);
            }
            string mess = "�� ������ " + ChannelWithNewContent.channelName + " ����� ����� �����!";
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