using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;


namespace xAPI.Records
{
    public record NewsTopicRecord : IBaseResponseRecord
    {
        private string body;
        private long? bodylen;
        private string key;
        private long? time;
        private string timeString;
        private string title;

        public virtual string Body => body;

        public virtual long? Bodylen => bodylen;

        [Obsolete("Field removed from API")]
        public virtual string Category => null;

        public virtual string Key => key;

        [Obsolete("Field removed from API")]
        public virtual LinkedList<string> Keywords => null;

        [Obsolete("Field removed from API")]
        public virtual long? Priority => new long?();

        [Obsolete("Field removed from API")]
        public virtual bool? Read => new bool?();

        public virtual long? Time => time;

        public virtual string TimeString => timeString;

        public virtual string Title => title;

        [Obsolete("Use Title instead")]
        public virtual string Topic => title;

        public void FieldsFromJSONObject(JObject value)
        {
            body = (string)value["body"];
            bodylen = (long?)value["bodylen"];
            key = (string)value["key"];
            time = (long?)value["time"];
            timeString = (string)value["timeString"];
            title = (string)value["title"];
        }
    }
}
