using System.Messaging;

namespace yesmarket.Messaging.Msmq.Extensions
{
    public static class MessageExtensions
    {
        public static T ReadFromJson<T>(this Message value)
        {
            return value.BodyStream.ReadFromJson<T>();
        }

        public static T BodyAs<T>(this Message value) where T : class
        {
            return value != null ? value.Body as T : null;
        }
    }
}