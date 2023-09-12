using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MqttLib.Model
{
    public class MqttMessage
    {
        public string Topic { get; }
        public string Message { get; }
        
        public MqttMessage(string topic, string message)
        {
            Topic = topic;
            Message = message;
        }
    }
}
