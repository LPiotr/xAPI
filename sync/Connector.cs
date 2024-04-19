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
    private object writeLocker = new object();

    public event Connector.OnReceiveMessageCallback OnMessageReceived;

    public event Connector.OnSendMessageCallback OnMessageSended;

    public event Connector.OnDisconnectCallback OnDisconnected;

    public bool Connected() => this.apiConnected;

    protected void WriteMessage(string message)
    {
      lock (this.writeLocker)
      {
        if (this.Connected())
        {
          try
          {
            this.apiWriteStream.WriteLine(message);
            this.apiWriteStream.Flush();
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
        byte[] numArray = new byte[this.apiSocket.ReceiveBufferSize];
        string str;
        while ((str = this.apiReadStream.ReadLine()) != null)
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
          this.Disconnect();
          throw new APICommunicationException("Disconnected from server");
        }
        if (this.OnMessageReceived != null)
          this.OnMessageReceived(stringBuilder.ToString());
        return stringBuilder.ToString();
      }
      catch (Exception ex)
      {
        this.Disconnect();
        throw new APICommunicationException("Disconnected from server: " + ex.Message);
      }
    }

    public void Disconnect(bool silent = false)
    {
      if (this.Connected())
      {
        this.apiReadStream.Close();
        this.apiWriteStream.Close();
        this.apiSocket.Close();
        if (!silent && this.OnDisconnected != null)
          this.OnDisconnected();
      }
      this.apiConnected = false;
    }

    public void Dispose()
    {
      this.apiReadStream.Close();
      this.apiWriteStream.Close();
      this.apiSocket.Close();
    }

    public delegate void OnReceiveMessageCallback(string response);

    public delegate void OnSendMessageCallback(string message);

    public delegate void OnDisconnectCallback();
  }
}
