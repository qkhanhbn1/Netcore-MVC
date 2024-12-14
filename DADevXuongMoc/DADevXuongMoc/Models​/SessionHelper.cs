using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace YourNamespace.Helpers
{
    public static class SessionHelper
    {
        // Lưu một object vào Session
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            // Serialize object sang JSON và lưu vào Session
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        // Lấy một object từ Session
        public static T GetObject<T>(this ISession session, string key)
        {
            // Lấy chuỗi JSON từ Session
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        // Xóa một key trong Session
        public static void Remove(this ISession session, string key)
        {
            session.Remove(key);
        }
    }
}
