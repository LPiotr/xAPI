using Newtonsoft.Json.Linq;

namespace xAPI.Records
{
    public record StreamingProfitRecord : BaseResponseRecord
    {
        private long? order;
        private long? order2;
        private long? position;
        private double? profit;

        public long? Order
        {
            get => order;
            set => order = value;
        }

        public long? Order2
        {
            get => order2;
            set => order2 = value;
        }

        public long? Position
        {
            get => position;
            set => position = value;
        }

        public double? Profit
        {
            get => profit;
            set => profit = value;
        }

        public void FieldsFromJSONObject(JObject value)
        {
            profit = (double?)value["profit"];
            order = (long?)value["order"];
        }

        public override string ToString()
        {
            return "StreamingProfitRecord{profit=" + (object)profit + ", order=" + (object)order + (object)'}';
        }
    }
}
