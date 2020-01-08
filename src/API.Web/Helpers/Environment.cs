using System;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace API.Web.Helpers
{
    public class Environment
    {
        public enum EnvVariable {
            [Key("LAUNC_DEFAULT_CONNECTION_STRING")]
            DefaultConnectionString,

            [Key("MOLLIE_KEY")]
            MollieKey,
            [Key("MOLLIE_REDIRECT_URL")]
            MollieRedirectURL,
            [Key("MOLLIE_WEBHOOK_URL")]
            MollieWebhookUrl
        }

        private readonly IConfiguration _configuration;

        public Environment(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private static string EnvironmentKey(EnvVariable env) {
            Type type = env.GetType();

            MemberInfo[] memInfo = type.GetMember(env.ToString());

            if (memInfo != null && memInfo.Length > 0) {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(Key), false);

                if (attrs != null && attrs.Length > 0)
                    return ((Key)attrs[0]).key;
            }

            return null;
        }

        public static string EnvironmentVariable(EnvVariable env) {
            return System.Environment.GetEnvironmentVariable(EnvironmentKey(env));
        }

        public static string EnvironmentValueOrDefault(EnvVariable env, string defaultValue) {
            string var = EnvironmentVariable(env);

            if (string.IsNullOrEmpty(var))
                return defaultValue;

            return var;
        }

        public string GetEnvOrConfig(string section, string configkey, EnvVariable envVariable)
        {
            string configValue = GetConfigValue(section, configkey);

            return Environment.EnvironmentValueOrDefault(
                envVariable,
                configValue
            );
        }

        private string GetConfigValue(string section, string key) {
            return _configuration
                .GetSection("AppSettings")
                .GetSection(section)[key];
        }


        public class Key : Attribute {
            public string key;

            public Key(string value)
            {
                this.key = value;
            }
        }
    }
}