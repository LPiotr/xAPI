using Newtonsoft.Json.Linq;

namespace xAPI.Records
{
  public class StreamingBalanceRecord : BaseResponseRecord
  {
    private double? balance;
    private double? margin;
    private double? marginFree;
    private double? marginLevel;
    private double? equity;
    private double? credit;

    public double? Balance
    {
      get => this.balance;
      set => this.balance = value;
    }

    public double? Margin
    {
      get => this.margin;
      set => this.margin = value;
    }

    public double? MarginFree
    {
      get => this.marginFree;
      set => this.marginFree = value;
    }

    public double? MarginLevel
    {
      get => this.marginLevel;
      set => this.marginLevel = value;
    }

    public double? Equity
    {
      get => this.equity;
      set => this.equity = value;
    }

    public double? Credit
    {
      get => this.credit;
      set => this.credit = value;
    }

    public void FieldsFromJSONObject(JObject value)
    {
      this.Balance = (double?) value["balance"];
      this.Margin = (double?) value["margin"];
      this.MarginFree = (double?) value["marginFree"];
      this.MarginLevel = (double?) value["marginLevel"];
      this.Equity = (double?) value["equity"];
      this.Credit = (double?) value["credit"];
    }

    public override string ToString()
    {
      return "StreamingBalanceRecord{balance=" + (object) this.Balance + ", margin=" + (object) this.Margin + ", marginFree=" + (object) this.MarginFree + ", marginLevel=" + (object) this.MarginLevel + ", equity=" + (object) this.Equity + ", credit=" + (object) this.Credit + (object) '}';
    }
  }
}
