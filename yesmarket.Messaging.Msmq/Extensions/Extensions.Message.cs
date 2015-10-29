using System.IO;
using System.Messaging;
using Newtonsoft.Json;

namespace yesmarket.Messaging.Msmq.Extensions
{
    public static class MessageExtensions
    {
        public static T FromJsonOf<T>(this Message value)
        {
            var reader = new StreamReader(value.BodyStream);
            var serializedMessage = reader.ReadToEnd();
            var obj = JsonConvert.DeserializeObject<T>(serializedMessage);
            return obj;
        }
    }
}