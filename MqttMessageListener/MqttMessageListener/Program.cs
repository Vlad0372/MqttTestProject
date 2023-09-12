using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MqttLib;
using MqttLib.Model;

namespace MqttMessageListener
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string topic;

            while (true)
            {
                Console.WriteLine("\nSpecify the topic`s name:\n");

                topic = Console.ReadLine();

                if (topic.Length < 2)
                {
                    Console.Clear();
                    Console.WriteLine("\nTopic`s name length should be at least 2");
                }
                else
                {
                    Console.Clear();

                    MqttMessage mqttMessage = new MqttMessage(topic, "");

                    MqttManager mqttManager = new MqttManager(mqttMessage);

                    mqttManager.SubsctibeToTopic();

                    Console.WriteLine("Now you're listening the '{0}' topic!\n", topic);

                    return;
                }
            }
        }
    }
}
