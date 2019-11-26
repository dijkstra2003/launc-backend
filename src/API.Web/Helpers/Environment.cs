namespace API.Web.Helpers
{
    public class Environment
    {
        public static string EnvironmentValueOrDefault(string environmentName, string defaultValue) {
            string env = System.Environment.GetEnvironmentVariable(environmentName);

            if (string.IsNullOrEmpty(env))
                return defaultValue;

            return env;
        }
    }
}