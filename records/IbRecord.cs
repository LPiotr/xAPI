using Newtonsoft.Json.Linq;
using xAPI.Codes;

namespace xAPI.Records
{
    public record IbRecord : IBaseResponseRecord
    {
        public double ClosePrice { get; set; }
        public string Login { get; set; }
        public double Nominal { get; set; }
        public double OpenPrice { get; set; }
        public Side Side { get; set; }
        public string Surname { get; set; }
        public string Symbol { get; set; }
        public long Timestamp { get; set; }
        public double Volume { get; set; }

        public IbRecord()
        {
        }

        public IbRecord(JObject value) => FieldsFromJSONObject(value);

        public void FieldsFromJSONObject(JObject value)
        {
            ClosePrice = (double)value["closePrice"];
            Login = (string)value["login"];
            Nominal = (double)value["nominal"];
            OpenPrice = (double)value["openPrice"];
            Side = Side.FromCode((int)value["side"]);
            Surname = (string)value["surname"];
            Symbol = (string)value["symbol"];
            Timestamp = (long)value["timestamp"];
            Volume = (double)value["volume"];
        }
    }
}
