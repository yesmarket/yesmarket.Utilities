using System.IO;
using System.Messaging;
using System.Text;
using Newtonsoft.Json;

namespace yesmarket.Messaging.Msmq.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToJsonString(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static Stream ToJsonStream(this object obj)
        {
            var json = obj.ToJsonString();
            return new MemoryStream(Encoding.Default.GetBytes(json));
        }

        public static Message ToJsonMessage<T>(this T value)
        {
            return new Message {BodyStream = value.ToJsonStream()};
        }
    }
}