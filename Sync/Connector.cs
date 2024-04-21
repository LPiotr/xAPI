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
        private readonly object writeLocker = new();
        private bool disposedValue = false;
        public event OnReceiveMessageCallback OnMessageReceived;

        public event OnSendMessageCallback OnMessageSended;

        public event OnDisconnectCallback OnDisconnected;

        public bool Connected() => apiConnected;

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
                        Disconnect();
                        throw new APICommunicationException("Error while sending the data: " + ex.Message);
                    }
                    if (OnMessageSended == null)
                        return;
                    OnMessageSended(message);
                }
                else
                {
                    Disconnect();
                    throw new APICommunicationException("Error while sending the data (socket disconnected)");
                }
            }
        }

        protected string ReadMessage()
        {
            StringBuilder stringBuilder = new();
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
                            ch = str[^1];
                    }
                    else
                        break;
                }

                if (str == null)
                {
                    Disconnect();
                    throw new APICommunicationException("Disconnected from server");
                }

                OnMessageReceived?.Invoke(stringBuilder.ToString());
                
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
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Disconnect(silent: true);
                    apiReadStream.Dispose();
                    apiWriteStream.Dispose();
                    apiSocket.Dispose();
                }

                disposedValue = true;
            }
        }

        public delegate void OnReceiveMessageCallback(string response);

        public delegate void OnSendMessageCallback(string message);

        public delegate void OnDisconnectCallback();
    }
}
