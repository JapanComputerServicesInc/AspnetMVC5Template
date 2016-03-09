using Newtonsoft.Json;

namespace MVC5Template.Extensions
{
    public class JsonManager<T>
    {
        /// <summary>
        /// オブジェクトをJsonテキストに変換して、返します
        /// </summary>
        /// <param name="value">Jsonテキスト</param>
        /// <returns>変換先オブジェクト</returns>
        public static string SerializeObject(object value)
        {
            return JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.Indented, new JsonConverter(typeof(T)));
        }

        /// <summary>
        /// JsonテキストをJson形式のオブジェクトに変換して、返します
        /// </summary>
        /// <param name="value">変換元オブジェクト</param>
        /// <returns>Jsonテキスト</returns>
        public static T DeserializeObject(string value)
        {
            return JsonConvert.DeserializeObject<T>(value, new JsonConverter(typeof(T)));
        }


    }
}