using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using xAPI.Errors;


namespace xAPI.Sync
{
    public class Connector : IDisposable
    {
        protected TcpClient apiSocket;
        protected StreamWriter apiWriteStream;
        protected StreamReader apiReadStream;
        protected volatile bool apiConnected;
        protected Server server;
        private object writeLocker = new();

        public event OnReceiveMessageCallback OnMessageReceived;

        public event OnSendMessageCallback OnMessageSended;

        public event OnDisconnectCallback OnDisconnected;

        public bool Connected() => this.apiConnected;

        protected void WriteMessage(string message)
        {
            lock (writeLocker)
            {
                if (Connected())
                {
                    try
                    {
                        apiWriteStream.WriteLine(message);
                        apiWriteStream.Flush();
                    }
                    catch (IOException ex)
                    {
                        this.Disconnect();
                        throw new APICommunicationException("Error while sending the data: " + ex.Message);
                    }
                    if (this.OnMessageSended == null)
                        return;
                    this.OnMessageSended(message);
                }
                else
                {
                    this.Disconnect();
                    throw new APICommunicationException("Error while sending the data (socket disconnected)");
                }
            }
        }

        protected string ReadMessage()
        {
            StringBuilder stringBuilder = new StringBuilder();
            char ch = ' ';
            try
            {
                byte[] numArray = new byte[apiSocket.ReceiveBufferSize];
                string str;
                while ((str = apiReadStream.ReadLine()) != null)
                {
                    stringBuilder.Append(str);
                    if (!(str == "") || ch != '}')
                    {
                        if (str.Length != 0)
                            ch = str[str.Length - 1];
                    }
                    else
                        break;
                }
                if (str == null)
                {
                    Disconnect();
                    throw new APICommunicationException("Disconnected from server");
                }
                if (OnMessageReceived != null)
                    OnMessageReceived(stringBuilder.ToString());
                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                Disconnect();
                throw new APICommunicationException("Disconnected from server: " + ex.Message);
            }
        }

        public void Disconnect(bool silent = false)
        {
            if (Connected())
            {
                apiReadStream.Close();
                apiWriteStream.Close();
                apiSocket.Close();
                if (!silent && OnDisconnected != null)
                    OnDisconnected();
            }
            apiConnected = false;
        }

        public void Dispose()
        {
            apiReadStream.Close();
            apiWriteStream.Close();
            apiSocket.Close();
        }

        public delegate void OnReceiveMessageCallback(string response);

        public delegate void OnSendMessageCallback(string message);

        public delegate void OnDisconnectCallback();
    }
}
