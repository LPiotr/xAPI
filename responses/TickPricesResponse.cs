using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using xAPI.Records;


namespace xAPI.Responses
{
    public class TickPricesResponse : BaseResponse
    {
        private readonly LinkedList<TickRecord> ticks = new();

        public TickPricesResponse(string body)
          : base(body)
        {
            foreach (JObject jobject in ((JObject)ReturnData)["quotations"].Cast<JObject>())
            {
                TickRecord tickRecord = new();
                tickRecord.FieldsFromJSONObject(jobject);
                ticks.AddLast(tickRecord);
            }
        }

        public virtual LinkedList<TickRecord> Ticks => ticks;
    }
}
