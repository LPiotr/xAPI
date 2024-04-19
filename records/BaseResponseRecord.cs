using Newtonsoft.Json.Linq;

namespace xAPI.Records
{
  public interface BaseResponseRecord
  {
    void FieldsFromJSONObject(JObject value);
  }
}
