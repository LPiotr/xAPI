namespace xAPI.Sync
{
    public class Server
    {
        private string address;
        private int mainPort;
        private int streamingPort;
        private string description;
        private bool secure;

        public Server(
          string address,
          int mainPort,
          int streamingPort,
          bool secure,
          string description)
        {
            this.address = address;
            this.mainPort = mainPort;
            this.streamingPort = streamingPort;
            this.secure = secure;
            this.description = description;
        }

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
