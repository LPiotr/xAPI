﻿// Decompiled with JetBrains decompiler
// Type: xAPI.Records.NewsTopicRecord
// Assembly: xAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9383CE98-29AB-4755-8B1A-45B976BB72F4
// Assembly location: C:\Users\Piotr\Downloads\xAPI25-XTB-net\xAPI25-XTB-net\src\xAPITest\bin\Release\xAPI.dll

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;


namespace xAPI.Records
{
  public class NewsTopicRecord : BaseResponseRecord
  {
    private string body;
    private long? bodylen;
    private string key;
    private long? time;
    private string timeString;
    private string title;

    public virtual string Body => this.body;

    public virtual long? Bodylen => this.bodylen;

    [Obsolete("Field removed from API")]
    public virtual string Category => (string) null;

    public virtual string Key => this.key;

    [Obsolete("Field removed from API")]
    public virtual LinkedList<string> Keywords => (LinkedList<string>) null;

    [Obsolete("Field removed from API")]
    public virtual long? Priority => new long?();

    [Obsolete("Field removed from API")]
    public virtual bool? Read => new bool?();

    public virtual long? Time => this.time;

    public virtual string TimeString => this.timeString;

    public virtual string Title => this.title;

    [Obsolete("Use Title instead")]
    public virtual string Topic => this.title;

    public void FieldsFromJSONObject(JObject value)
    {
      this.body = (string) value["body"];
      this.bodylen = (long?) value["bodylen"];
      this.key = (string) value["key"];
      this.time = (long?) value["time"];
      this.timeString = (string) value["timeString"];
      this.title = (string) value["title"];
    }
  }
}
