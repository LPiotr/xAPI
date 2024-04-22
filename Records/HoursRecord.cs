﻿using Newtonsoft.Json.Linq;

namespace xAPI.Records
{
    public class HoursRecord : IBaseResponseRecord
    {
        private long? day;
        private long? fromT;
        private long? toT;

        public virtual long? Day => day;

        public virtual long? FromT => fromT;

        public virtual long? ToT => toT;

        public void FieldsFromJSONObject(JObject value)
        {
            day = (long?)value["day"];
            fromT = (long?)value["fromT"];
            toT = (long?)value["toT"];
        }

        public override string ToString()
        {
            return "HoursRecord{day=" + day + ", fromT=" + fromT + ", toT=" + toT + '}';
        }
    }
}
