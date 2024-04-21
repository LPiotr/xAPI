using Newtonsoft.Json.Linq;

namespace xAPI.Records
{
    public record RateInfoRecord : BaseResponseRecord
    {
        private long? ctm;
        private double? open;
        private double? high;
        private double? low;
        private double? close;
        private double? vol;

        public virtual long? Ctm
        {
            get => ctm;
            set => ctm = value;
        }

        public virtual double? Open
        {
            get => open;
            set => open = value;
        }

        public virtual double? High
        {
            get => high;
            set => high = value;
        }

        public virtual double? Low
        {
            get => low;
            set => low = value;
        }

        public virtual double? Close
        {
            get => close;
            set => close = value;
        }

        public virtual double? Vol
        {
            get => vol;
            set => vol = value;
        }

        public void FieldsFromJSONObject(JObject value)
        {
            Close = (double?)value["close"];
            Ctm = (long?)value["ctm"];
            High = (double?)value["high"];
            Low = (double?)value["low"];
            Open = (double?)value["open"];
            Vol = (double?)value["vol"];
        }
    }
}
