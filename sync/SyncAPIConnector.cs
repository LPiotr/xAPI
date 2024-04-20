using Newtonsoft.Json.Linq;
using SyncAPIConnect.Utils;
using System;
using System.IO;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using xAPI.Commands;
using xAPI.Errors;
using xAPI.Utils;

namespace xAPI.Sync
{
    public class SyncAPIConnector : Connector
    {
        public const string VERSION = "2.5.0"; 
        private const long COMMAND_TIME_SPACE = 200;
        public const long MAX_REDIRECTS = 3;
        private const int TIMEOUT = 5000;
        private StreamingAPIConnector streamingConnector;
        private long lastCommandTimestamp = 0;
        private object locker = new object();

        public event OnConnectedCallback OnConnected;

        public event OnRedirectedCallback OnRedirected;

        
        public SyncAPIConnector(Server server, bool lookForBackups = true)
        {
            this.Connect(server, lookForBackups);
        }

        [Obsolete]
        private void Connect(Server server, bool lookForBackups = true)
        {
            this.server = server;
            this.apiSocket = new TcpClient();
            bool flag = false;
            while (!flag || !this.apiSocket.Connected)
            {
                flag = this.apiSocket.BeginConnect(this.server.Address, this.server.MainPort, (AsyncCallback)null, (object)null).AsyncWaitHandle.WaitOne(5000, true);
                if (!flag || !this.apiSocket.Connected)
                {
                    this.apiSocket.Close();
                    if (lookForBackups)
                    {
                        this.server = Servers.GetBackup(this.server);
                        this.apiSocket = new TcpClient();
                    }
                    else
                        throw new APICommunicationException("Cannot connect to: " + server.Address + ":" + (object)server.MainPort);
                }
            }
            if (server.Secure)
            {
                SslStream sl = new SslStream((Stream)this.apiSocket.GetStream(), false, new RemoteCertificateValidationCallback(SSLHelper.TrustAllCertificatesCallback));
                
                if (!ExecuteWithTimeLimit.Execute(TimeSpan.FromMilliseconds(5000.0), (Action)(() => 
                    sl.AuthenticateAsClient(server.Address, new X509CertificateCollection(), SslProtocols.Default, false))))
                    
                    throw new APICommunicationException("Error during SSL handshaking (timed out?)");
                
                apiWriteStream = new StreamWriter((Stream)sl);
                apiReadStream = new StreamReader((Stream)sl);
            }
            else
            {
                NetworkStream stream = this.apiSocket.GetStream();
                apiWriteStream = new StreamWriter(stream);
                apiReadStream = new StreamReader(stream);
            }
            this.apiConnected = true;
            if (this.OnConnected != null)
                this.OnConnected(this.server);
            this.streamingConnector = new StreamingAPIConnector(this.server);
        }

        public void Connect()
        {
            if (server != null)
                Connect(this.server);
            throw new APICommunicationException("No server to connect to");
        }

        [Obsolete("Use SyncAPIConnector(Server server) instead")]
        private SyncAPIConnector(string address, int port, bool secure)
          : this(new Server(address, port, port + 1, secure, ""))
        {
        }

        public void Redirect(Server server)
        {
            if (this.OnRedirected != null)
                this.OnRedirected(server);
            if (this.apiConnected)
                this.Disconnect(true);
            this.Connect(server);
        }

        public JObject ExecuteCommand(BaseCommand cmd)
        {
            try
            {
                return JObject.Parse(this.ExecuteCommand(cmd.ToJSONString()));
            }
            catch (Exception ex)
            {
                throw new APICommunicationException("Problem with executing command: " + ex.Message);
            }
        }

        public string ExecuteCommand(string message)
        {
            lock (this.locker)
            {
                DateTime now = DateTime.Now;
                long num = now.Ticks / 10000L - this.lastCommandTimestamp;
                if (num < 200L)
                    Thread.Sleep((int)(200L - num));
                this.WriteMessage(message);
                now = DateTime.Now;
                this.lastCommandTimestamp = now.Ticks / 10000L;
                string str = this.ReadMessage();
                if (str == null || str.Equals(""))
                {
                    this.Disconnect();
                    throw new APICommunicationException("Server not responding");
                }
                return str;
            }
        }

        [Obsolete("Use Streaming.Connect() instead")]
        public StreamingAPIConnector ConnectStreaming()
        {
            if (this.streamingConnector != null)
                this.streamingConnector.Disconnect();
            this.streamingConnector = new StreamingAPIConnector(this.server);
            return this.streamingConnector;
        }

        [Obsolete("Use Streaming.Disconnect() instead")]
        public void DisconnectStreaming()
        {
            if (this.streamingConnector == null)
                return;
            this.streamingConnector.Disconnect();
        }

        public StreamingAPIConnector Streaming => this.streamingConnector;

        public string StreamSessionId { get; set; }

        public delegate void OnConnectedCallback(Server server);

        public delegate void OnRedirectedCallback(Server server);
    }
}
