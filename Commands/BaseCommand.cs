using Newtonsoft.Json.Linq;
using xAPI.Errors;

namespace xAPI.Commands
{
    public abstract class BaseCommand
    {
        protected internal string commandName;
        protected internal bool? prettyPrint;
        protected internal JObject arguments;

        public BaseCommand(bool? prettyPrint)
          : this(new JObject(), prettyPrint)
        {
        }

        public BaseCommand(JObject arguments, bool? prettyPrint, string customTag = "")
        {
            this.commandName = this.CommandName;
            this.arguments = arguments;
            this.prettyPrint = prettyPrint;
            if (customTag == "")
                customTag = xAPI.Utils.CustomTag.Next();
            this.CustomTag = customTag;
            this.ValidateArguments();
        }

        public abstract string CommandName { get; }

        public string CustomTag { get; set; }

        public abstract string[] RequiredArguments { get; }

        public virtual bool ValidateArguments()
        {
            this.SelfCheck();
            foreach (string requiredArgument in this.RequiredArguments)
            {
                if (!this.arguments.TryGetValue(requiredArgument, out JToken _))
                    throw new APICommandConstructionException("Arguments of [" + this.commandName + "] Command must contain \"" + requiredArgument + "\" field!");
            }
            return true;
        }

        public virtual string ToJSONString()
        {
            return new JObject()
      {
        {
          "command",
          (JToken) this.commandName
        },
        {
          "prettyPrint",
          (JToken) this.prettyPrint
        },
        {
          "arguments",
          (JToken) this.arguments
        },
        {
          "customTag",
          (JToken) this.CustomTag
        }
      }.ToString();
        }

        private void SelfCheck()
        {
            if (this.commandName == null)
                throw new APICommandConstructionException("commandName cannot be null");
            if (this.arguments == null)
                throw new APICommandConstructionException("arguments cannot be null");
        }
    }
}
