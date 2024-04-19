// Decompiled with JetBrains decompiler
// Type: xAPI.Utils.SSLHelper
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

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
