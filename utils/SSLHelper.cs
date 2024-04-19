using System.Net.Security;
using System.Security.Cryptography.X509Certificates;


namespace xAPI.Utils
{
  internal class SSLHelper
  {
    public static bool TrustAllCertificatesCallback(
      object sender,
      X509Certificate cert,
      X509Chain chain,
      SslPolicyErrors errors)
    {
      return true;
    }
  }
}
