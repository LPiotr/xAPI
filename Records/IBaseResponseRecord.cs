using Newtonsoft.Json.Linq;

namespace xAPI.Records
{
    public interface IBaseResponseRecord
    {
        void FieldsFromJSONObject(JObject value);
    }
}
