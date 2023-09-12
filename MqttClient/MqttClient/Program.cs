using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MqttLib;
using MqttLib.Model;

namespace MqttClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message;
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
                    while(true)
                    {
                        Console.WriteLine("\nEnter message\n");

                        message = Console.ReadLine();

                        if (message.Length == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("\nMessage length should be at least 1");
                        }
                        else
                        {
                            MqttMessage mqttMessage = new MqttMessage(topic, message);

                            MqttManager mqttManager = new MqttManager(mqttMessage);

                            mqttManager.PublishMessage();
                        }
                    }                 
                }
            }
        }
    }
}
