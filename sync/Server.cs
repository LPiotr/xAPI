namespace xAPI.Sync
{
    public class Server(
      string address,
      int mainPort,
      int streamingPort,
      bool secure,
      string description)
    {
        private string address = address;
        private int mainPort = mainPort;
        private int streamingPort = streamingPort;
        private string description = description;
        private bool secure = secure;

        public string Address
        {
            get => address;
            set => address = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public int MainPort
        {
            get => mainPort;
            set => mainPort = value;
        }

        public int StreamingPort
        {
            get => streamingPort;
            set => streamingPort = value;
        }

        public bool Secure
        {
            get => secure;
            set => secure = value;
        }

        public override string ToString()
        {
            return Description + " (" + Address + ":" + MainPort + "/" + StreamingPort + ")";
        }
    }
}
