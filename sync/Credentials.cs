﻿using System;

namespace xAPI.Sync
{
    public class Credentials
    {
        private string login;
        private string password;
        private string appId;
        private string appName;

        [Obsolete("Up from 2.3.3 login is not a long, but string")]
        public Credentials(long login, string password, string appId = "", string appName = "")
        {
            this.login = login.ToString();
            this.password = password;
            this.appId = appId;
            this.appName = appName;
        }

        public Credentials(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public Credentials(string login, string password, string appId, string appName)
        {
            this.login = login;
            this.password = password;
            this.appId = appId;
            this.appName = appName;
        }

        public string Login => this.login;

        public string Password => this.password;

        public string AppId
        {
            get => this.appId;
            set => this.appId = value;
        }

        public string AppName
        {
            get => this.appName;
            set => this.appName = value;
        }

        public override string ToString()
        {
            return "Credentials [login=" + this.Login + ", password=" + this.Password + "]";
        }
    }
}
