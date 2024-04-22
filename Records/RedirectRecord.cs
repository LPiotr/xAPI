using Newtonsoft.Json.Linq;

namespace xAPI.Records
{
    public record RedirectRecord : IBaseResponseRecord
    {
        private int mainPort;
        private int streamingPort;
        private string address;

        public void FieldsFromJSONObject(JObject value)
        {
            mainPort = (int)value["mainPort"];
            streamingPort = (int)value["streamingPort"];
            address = (string)value["address"];
        }

        public int MainPort => mainPort;

        public int StreamingPort => streamingPort;

        public string Address => address;

        public override string ToString()
        {
            return "RedirectRecord [mainPort=" + mainPort + ", streamingPort=" + streamingPort + ", address=" + address + "]";
        }
    }
}
