﻿using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using xAPI.Records;


namespace xAPI.Responses
{
    public class SpreadsResponse : BaseResponse
    {
        private LinkedList<SpreadRecord> spreadRecords = new LinkedList<SpreadRecord>();

        public SpreadsResponse(string body) : base(body)
        {
            foreach (JObject jobject in ((IEnumerable<JToken>)ReturnData).Cast<JObject>())
            {
                SpreadRecord spreadRecord = new SpreadRecord();
                spreadRecord.FieldsFromJSONObject(jobject);
                this.spreadRecords.AddLast(spreadRecord);
            }
        }

        public virtual LinkedList<SpreadRecord> SpreadRecords => this.spreadRecords;
    }
}
