﻿using Newtonsoft.Json.Linq;

namespace xAPI.Records
{
    public record StepRecord : IBaseResponseRecord
    {
        private double FromValue;
        private double Step;

        public void FieldsFromJSONObject(JObject value)
        {
            FromValue = (double)value["fromValue"];
            Step = (double)value["step"];
        }
    }
}
