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
          : this([], prettyPrint)
        {
        }

        public BaseCommand(JObject arguments, bool? prettyPrint, string customTag = "")
        {
            commandName = CommandName;
            this.arguments = arguments;
            this.prettyPrint = prettyPrint;
            if (customTag == "")
                customTag = xAPI.Utils.CustomTag.Next();
            CustomTag = customTag;
            ValidateArguments();
        }

        public abstract string CommandName { get; }

        public string CustomTag { get; set; }

        public abstract string[] RequiredArguments { get; }

        public virtual bool ValidateArguments()
        {
            SelfCheck();
            foreach (string requiredArgument in RequiredArguments)
            {
                if (!arguments.TryGetValue(requiredArgument, out JToken _))
                    throw new APICommandConstructionException("Arguments of [" + commandName + "] Command must contain \"" + requiredArgument + "\" field!");
            }
            return true;
        }

        public virtual string ToJSONString()
        {
            return new JObject()
      {
        {
          "command",
          (JToken) commandName
        },
        {
          "prettyPrint",
          (JToken) prettyPrint
        },
        {
          "arguments",
          (JToken) arguments
        },
        {
          "customTag",
          (JToken) CustomTag
        }
      }.ToString();
        }

        private void SelfCheck()
        {
            if (commandName == null)
                throw new APICommandConstructionException("commandName cannot be null");
            if (arguments == null)
                throw new APICommandConstructionException("arguments cannot be null");
        }
    }
}
