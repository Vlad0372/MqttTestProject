using System;
using System.Text;
using MqttLib.Model;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MqttLib
{
    public class MqttManager
    {
        const string MQTT_BROKER_ADDRESS = "broker.hivemq.com";

        private readonly MqttMessage mqttMsg;
        public MqttManager(MqttMessage mqttMsg) 
        {
            this.mqttMsg = mqttMsg; 
        }
        public void SubsctibeToTopic()
        {
            try
            {
                MqttClient client = new MqttClient(MQTT_BROKER_ADDRESS);

                client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

                string clientId = Guid.NewGuid().ToString();
                client.Connect(clientId);

                client.Subscribe(new string[] { this.mqttMsg.Topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

                void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
                {
                    Console.WriteLine("\nNew message has been received!");
                    Console.WriteLine("Topic: {0}", e.Topic);
                    Console.WriteLine("Message: {0}\n", Encoding.Default.GetString(e.Message));
                }

                Console.WriteLine("\nYou've been successfully subscribed to the '{0}' topic!\n", this.mqttMsg.Topic);
            }
            catch (Exception)
            {
                Console.WriteLine("\nFailed to subscribe to the topic.\n");
            }          
        }
        public void PublishMessage()
        {
            try
            {
                MqttClient client = new MqttClient(MQTT_BROKER_ADDRESS);

                string clientId = Guid.NewGuid().ToString();
                client.Connect(clientId);

                string strValue = Convert.ToString(this.mqttMsg.Message);

                client.Publish(this.mqttMsg.Topic, Encoding.UTF8.GetBytes(strValue), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);

                Console.WriteLine("\nMessage has been successfully sent!\n");
            }
            catch (Exception)
            {
                Console.WriteLine("\nFailed to send the message.\n");
            }
        }
    }
}
