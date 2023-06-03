using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TAF_TMS_C1onl.Utilites.Helpers;

public class JsonHelper
{
    public static JObject FromJson(string json)
    {
        return JsonConvert.DeserializeObject<JObject>(json);
    }
}