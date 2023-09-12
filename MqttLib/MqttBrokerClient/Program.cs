using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MqttLib;
using MqttLib.Model;

namespace MqttBrokerClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("trying");
            MqttMessage mqttMessage = new MqttMessage();
            var mgttMenager = new MqttBrokerManager(mqttMessage);

            mgttMenager.SubsctibeToTopic("b");

            mgttMenager.PublishMessageOnTopic("bdasd");
            Console.WriteLine("bruh");
            Console.Read();
        }
    }
}
