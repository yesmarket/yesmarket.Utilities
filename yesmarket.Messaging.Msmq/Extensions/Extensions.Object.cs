using System.IO;
using System.Messaging;
using System.Text;
using Newtonsoft.Json;

namespace yesmarket.Messaging.Msmq.Extensions
{
    public static class ObjectExtensions
    {
        public static Message ToJsonMessage<T>(this T value)
        {
            var message = new Message();
            var serializedMessage = JsonConvert.SerializeObject(value);
            message.BodyStream = new MemoryStream(Encoding.Default.GetBytes(serializedMessage));
            return message;
        }
    }
}