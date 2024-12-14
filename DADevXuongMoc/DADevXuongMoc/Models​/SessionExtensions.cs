using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DADevXuongMoc.Extensions
{
    public static class SessionExtensions
    {
        // Lưu đối tượng vào session dưới dạng JSON
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            var json = JsonConvert.SerializeObject(value);
            session.SetString(key, json);
        }

        // Lấy đối tượng từ session dưới dạng JSON
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
